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


    }
}
