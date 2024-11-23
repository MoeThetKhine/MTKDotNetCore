namespace MTKDotNetCore.MiniKpay.Database.Models
{
    public class BaseResponseModel
    {
        public string RespCode { get; set; }
        public string RespDesp {  get; set; }
        public EnumRespType RespType { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }

        #region Success

        public static BaseResponseModel Success(string respCode,string respDesp)
        {
            return new BaseResponseModel
            {
                IsSuccess = true,
                RespCode = respCode,
                RespDesp = respDesp,
                RespType = EnumRespType.Success,
            };
        }

        #endregion

        #region ValidationError

        public static BaseResponseModel ValidationError(string respCode, string respDesp)
        {
            return new BaseResponseModel
            {
                IsSuccess = false,
                RespCode = respCode,
                RespDesp = respDesp,
                RespType = EnumRespType.ValidationError,
            };
        }

        #endregion

        

    }

    #region EnumRespType

    public enum EnumRespType
    {
        None,
        Success,
        ValidationError,
        SystemError
    }

    #endregion
}
