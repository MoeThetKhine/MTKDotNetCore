namespace MTKDotNetCore.MiniKpayDapperApi.Models.User
{
    public class UserResponseModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public string Pin { get; set; }
        public string Password { get; set; }
    }
}
