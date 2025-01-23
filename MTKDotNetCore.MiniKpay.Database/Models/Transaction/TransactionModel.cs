namespace MTKDotNetCore.MiniKpay.Database.Models.Transaction;

#region Transaction Model

public class TransactionModel
{
    public int Transaction_Id { get; set; }
    public string FromPhoneNumber { get; set; }
    public string ToPhoneNumber { get; set; }
    public decimal Amount { get; set; }
    public string Pin { get; set; }
    public bool DeleteFlag { get; set; }
}

#endregion
