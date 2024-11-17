using MTKDotNetCore.MiniKpay.Database.Models.User;

namespace MTKDotNetCore.MiniKpay.Database.DataAccess.User
{
    public class DataAccess_User
    {
        private readonly DapperService _dapperService;

        public DataAccess_User(DapperService dapperService)
        {
            _dapperService = dapperService;
        }

        #region GetUserList

        public List<UserModel> GetUserList()
        {
            string query = "SELECT * FROM Tbl_User WHERE DeleteFlag = 0;";
            return _dapperService.Query<UserModel>(query).ToList() ;
        }

        #endregion

        #region GetUserByUserId

        public UserModel GetUserByUserId(int userId)
        {
            string query = "SELECT * FROM Tbl_User WHERE User_Id = @UserId AND DeleteFlag = 0;";
            return _dapperService.QueryFirstOrDefault<UserModel>(query, new { UserId = userId });
        }

        #endregion

        #region CheckPhoneNumberExists

        public int CheckPhoneNumberExists(string phoneNumber)
        {
            string query = "SELECT * FROM Tbl_User WHERE PhoneNumber = @PhoneNumber AND DeleteFlag = 0;";
            return _dapperService.QueryFirstOrDefault<int>(query, new { PhoneNumber = phoneNumber });
        }

        #endregion

        #region CheckPinExists

        public int CheckPinExists(string pin)
        {
            string query = "SELECT * FROM Tbl_User WHERE Pin = @Pin AND DeleteFlag = 0;";
            return _dapperService.QueryFirstOrDefault<int>(query, new { Pin = pin });
        }

        #endregion

        #region CreateUser

        public int CreateUser(UserResponseModel responseModel)
        {
            string query = @"INSERT INTO Tbl_User (FullName, Password, Pin, PhoneNumber, Balance, DeleteFlag) 
                         VALUES (@FullName, @Password, @Pin, @PhoneNumber, @Balance, 0);";
            return _dapperService.Execute(query, responseModel);
        }

        #endregion

        #region UpdateUser

        public int UpdateUser(int userId, UserRequestModel user)
        {
            string query = @"UPDATE Tbl_User SET FullName = @FullName, Pin = @Pin, 
                         PhoneNumber = @PhoneNumber, DeleteFlag = 0 WHERE User_Id = @UserId;";
            return _dapperService.Execute(query, new
            {
                UserId = userId,
                FullName = user.FullName,
                Pin = user.Pin,
                PhoneNumber = user.PhoneNumber
            });
        }

        #endregion


    }
}
