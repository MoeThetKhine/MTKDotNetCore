namespace MTKDotNetCore.MiniKpay.Database.DataAccess.User;

public class DataAccess_User
{
    private readonly DapperService _dapperService;

    public DataAccess_User(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    #region GetUserList

    public async Task<List<UserModel>> GetUserList()
    {
        string query = "SELECT * FROM Tbl_User WHERE DeleteFlag = 0;";
        var result = await _dapperService.QueryAsync<UserModel>(query);
        return result.ToList();
    }

    #endregion

    #region GetUserByUserId

    public async Task<UserModel> GetUserByUserIdAsync(int userId)
    {
        string query = "SELECT * FROM Tbl_User WHERE User_Id = @UserId AND DeleteFlag = 0;";
        return await _dapperService.QueryFirstOrDefaultAsync<UserModel>(query, new { UserId = userId });
    }

    #endregion

    #region CheckPhoneNumberExists

    public async Task<int> CheckPhoneNumberExistsAsync(string phoneNumber)
    {
        string query = "SELECT COUNT(1) FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
        return await _dapperService.QueryFirstOrDefaultAsync<int>(query, new { PhoneNumber = phoneNumber });
    }

    #endregion

    #region CheckPinExists

    public async Task<int> CheckPinExistsAsync(string pin)
    {
        string query = "SELECT COUNT(1) FROM Tbl_User WHERE Pin = @Pin AND DeleteFlag = 0;";
        return await _dapperService.QueryFirstOrDefaultAsync<int>(query, new { Pin = pin });
    }

    #endregion

    #region CreateUser

    public async Task<int> CreateUserAsync(UserResponseModel responseModel)
    {
        string query = @"INSERT INTO Tbl_User (FullName, Password, Pin, PhoneNumber, Balance, DeleteFlag) 
                             VALUES (@FullName, @Password, @Pin, @PhoneNumber, @Balance, 0);";
        return await _dapperService.ExecuteAsync(query, responseModel);
    }

    #endregion

    #region UpdateUser

    public async Task<int> UpdateUserAsync(int userId, UserRequestModel user)
    {
        string query = @"UPDATE Tbl_User 
                             SET FullName = @FullName, Pin = @Pin, PhoneNumber = @PhoneNumber 
                             WHERE User_Id = @UserId AND DeleteFlag = 0;";
        return await _dapperService.ExecuteAsync(query, new
        {
            UserId = userId,
            FullName = user.FullName,
            Pin = user.Pin,
            PhoneNumber = user.PhoneNumber
        });
    }

    #endregion

    #region SoftDeleteUser

    public async Task<int> SoftDeleteUserAsync(int userId)
    {
        string query = "UPDATE Tbl_User SET DeleteFlag = 1 WHERE User_Id = @UserId;";
        return await _dapperService.ExecuteAsync(query, new { UserId = userId });
    }

    #endregion

}
