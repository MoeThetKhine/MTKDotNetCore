namespace MTKDotNetCore.MiniKpayDapperApi.Models.Withdraw
{
    public class WithdrawResponseModel
    {
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
