namespace MTKDotNetCore.MiniKpayDapperApi.Models.Deposit;

public class DepositModel
{
    public int Deposit_Id { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Balance { get; set; }
    public bool DeleteFlag { get; set; }
}
