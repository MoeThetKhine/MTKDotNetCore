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

    }
}
