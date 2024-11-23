namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.User;

public class BusinessLogic_User
{
    private readonly DataAccess_User _dA_User;

    public BusinessLogic_User(DataAccess_User dA_User)
    {
        _dA_User = dA_User;
    }

    #region GetUserList

    public async Task<Result<List<UserModel>>> GetUserListAsync()
    {
        var userList = await _dA_User.GetUserListAsync();

        if (userList is null)
        {
            return Result<List<UserModel>>.ValidationError("No users found.");
        }

        return Result<List<UserModel>>.Success(userList, "User list retrieved successfully.");
    }
    #endregion

    #region GetUserByUserId

    public async Task<Result<UserModel>> GetUserByUserIdAsync(int userId)
    {
        var user = await _dA_User.GetUserByUserIdAsync(userId);

        if (user is null)
        {
            return Result<UserModel>.ValidationError("User not found.");
        }

        return Result<UserModel>.Success(user, "User retrieved successfully.");
    }

    #endregion

    #region CreateUser

    public async Task<Result<bool>> CreateUserAsync(UserResponseModel responseModel)
    {
        if (await _dA_User.CheckPhoneNumberExistsAsync(responseModel.PhoneNumber) > 0)
        {
            return Result<bool>.ValidationError("Phone number already exists. Please use a different phone number.");
        }

        if (responseModel.PhoneNumber.Length != 10)
        {
            return Result<bool>.ValidationError("Phone number must be exactly 10 digits.");
        }

        if (responseModel.Pin.Length != 8)
        {
            return Result<bool>.ValidationError("Pin must be exactly 8 characters.");
        }

        if (responseModel.Balance < 10000)
        {
            return Result<bool>.ValidationError("Balance must be at least 10000 Kyats.");
        }

        if (await _dA_User.CheckPinExistsAsync(responseModel.Pin) > 0)
        {
            return Result<bool>.ValidationError("This Pin is already in use by another user.");
        }

        int result = await _dA_User.CreateUserAsync(responseModel);
        return result == 1
            ? Result<bool>.Success(true, "User registration successful.")
            : Result<bool>.SystemError(false, "User registration failed.");
    }

    #endregion

    #region UpdateUser

    public async Task<Result<bool>> UpdateUserAsync(int userId, UserRequestModel user)
    {
        var existingUser = await _dA_User.GetUserByUserIdAsync(userId);
        if (existingUser is null)
        {
            return Result<bool>.ValidationError("User not found.");
        }

        if (await _dA_User.CheckPhoneNumberExistsAsync(user.PhoneNumber) > 0)
        {
            return Result<bool>.ValidationError("Phone number is already in use by another user.");
        }

        int result = await _dA_User.UpdateUserAsync(userId, user);
        return result == 1
            ? Result<bool>.Success(true, "Update successful.")
            : Result<bool>.SystemError(false, "Update failed.");
    }

    #endregion

    #region DeleteUser

    public async Task<Result<bool>> DeleteUserAsync(int userId)
    {
        var user = await _dA_User.GetUserByUserIdAsync(userId);
        if (user is null)
        {
            return Result<bool>.ValidationError("User not found.");
        }

        int result = await _dA_User.SoftDeleteUserAsync(userId);
        return result == 1
            ? Result<bool>.Success(true, "User deleted successfully.")
            : Result<bool>.SystemError(false, "Deletion failed.");
    }

    #endregion

}
