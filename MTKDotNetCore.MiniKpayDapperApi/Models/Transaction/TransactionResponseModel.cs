namespace MTKDotNetCore.MiniKpayDapperApi.Models.Transaction
{
    public class TransactionResponseModel
    {
        public string FromPhoneNumber { get; set; }
        public string ToPhoneNumber { get; set; }
        public decimal Amount { get; set; }
        public string Pin { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
