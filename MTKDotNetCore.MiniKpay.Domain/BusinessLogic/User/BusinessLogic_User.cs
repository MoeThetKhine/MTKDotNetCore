namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.User;

public class BusinessLogic_User
{
    private readonly DataAccess_User _dA_User;

    public BusinessLogic_User(DataAccess_User dA_User)
    {
        _dA_User = dA_User;
    }

    #region GetUserList

    public async Task<List<UserModel>> GetUserListAsync()
    {
        return await _dA_User.GetUserListAsync();
    }

    #endregion

    #region GetUserByUserId

    public async Task<UserModel> GetUserByUserIdAsync(int userId)
    {
        return await _dA_User.GetUserByUserIdAsync(userId);
    }

    #endregion

    #region CreateUser

    public async Task<string> CreateUserAsync(UserResponseModel responseModel)
    {
        if (await _dA_User.CheckPhoneNumberExistsAsync(responseModel.PhoneNumber) > 0)
        {
            return "Phone number already exists. Please use a different phone number.";
        }

        if (responseModel.PhoneNumber.Length != 10)
        {
            return "Phone number must be exactly 10 digits.";
        }

        if (responseModel.Pin.Length != 8)
        {
            return "Pin must be exactly 8 characters.";
        }

        if (responseModel.Balance < 10000)
        {
            return "Balance must be at least 10000 Kyats.";
        }

        if (await _dA_User.CheckPinExistsAsync(responseModel.Pin) > 0)
        {
            return "This Pin is already in use by another user.";
        }

        int result = await _dA_User.CreateUserAsync(responseModel);
        return result == 1 ? "User registration successful." : "User registration failed.";
    }

    #endregion

    #region UpdateUser

    public async Task<string> UpdateUserAsync(int userId, UserRequestModel user)
    {
        if (await _dA_User.GetUserByUserIdAsync(userId) == null)
        {
            return "User not found.";
        }

        if (await _dA_User.CheckPhoneNumberExistsAsync(user.PhoneNumber) > 0)
        {
            return "Phone number is already in use by another user.";
        }

        int result = await _dA_User.UpdateUserAsync(userId, user);
        return result == 1 ? "Update successful." : "Update failed.";
    }

    #endregion

    #region DeleteUser

    public async Task<string> DeleteUserAsync(int userId)
    {
        if (await _dA_User.GetUserByUserIdAsync(userId) == null)
        {
            return "User not found.";
        }

        int result = await _dA_User.SoftDeleteUserAsync(userId);
        return result == 1 ? "User deleted successfully." : "Deletion failed.";
    }

    #endregion

}
