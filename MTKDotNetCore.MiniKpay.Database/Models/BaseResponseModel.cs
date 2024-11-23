namespace MTKDotNetCore.MiniKpay.Database.Models
{
    public class BaseResponseModel
    {
        public string RespCode { get; set; }
        public string RespDesp {  get; set; }
        public EnumRespType RespType { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }

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
