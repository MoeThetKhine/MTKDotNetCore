using MTKDotNetCore.MiniKpay.Database.DataAccess.User;
using MTKDotNetCore.MiniKpay.Database.Models.User;

namespace MTKDotNetCore.MiniKpay.Domain.BusinessLogic.User
{
    public class BusinessLogic_User
    {
        private readonly DataAccess_User _dA_User;

        public BusinessLogic_User(DataAccess_User dA_User)
        {
            _dA_User = dA_User;
        }

        #region GetUserList

        public List<UserModel> GetUserList()
        {
            return _dA_User.GetUserList();
        }

        #endregion

        #region GetUserByUserId

        public UserModel GetUserByUserId(int userId)
        {
            return _dA_User.GetUserByUserId(userId);
        }

        #endregion

    }
}

