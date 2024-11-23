using MTKDotNetCore.MiniKpay.Database.Models;

namespace MTKDotNetCore.MiniKpay.Domain
{
    public class Result<T>
    {
        public bool IsSuccess {  get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public EnumRespType Type { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        #region Success

        public static Result<T> Success<T>(T data,string message = "Success")
        {
            return new Result<T>()
            {
                IsSuccess = true,
                Type = EnumRespType.Success,
                Data = data,
                Message = message
            };
        }

        #endregion

        #region ValidationError

        public static Result<T> ValidationError(string message, T? data = default)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Type = EnumRespType.ValidationError,
                Data = data,
                Message = message
            };
        }

        #endregion

        #region SystemError

        public static Result<T> SystemError(T? data,string message)
        {
            return new Result<T>()
            {
                IsSuccess = false,
                Type = EnumRespType.SystemError,
                Data = data,
                Message = message
            };
        }

        #endregion

    }

}
