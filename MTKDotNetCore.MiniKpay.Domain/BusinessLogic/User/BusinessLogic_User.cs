﻿using MTKDotNetCore.MiniKpay.Database.DataAccess.User;
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

        #region CreateUser

        public string CreateUser(UserResponseModel responseModel)
        {
            if (_dA_User.CheckPhoneNumberExists(responseModel.PhoneNumber) > 0)
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

            if (_dA_User.CheckPinExists(responseModel.Pin) > 0)
            {
                return "This Pin is already in use by another user.";
            }

            int result = _dA_User.CreateUser(responseModel);
            return result == 1 ? "User registration successful." : "User registration failed.";
        }

        #endregion

    }
}

