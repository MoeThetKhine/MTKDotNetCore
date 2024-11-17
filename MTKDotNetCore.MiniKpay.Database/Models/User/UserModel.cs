namespace MTKDotNetCore.MiniKpay.Database.Models.User;

public class UserModel
{
    public int User_Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Balance { get; set; }
    public string Pin { get; set; }
    public string Password { get; set; }
    public bool DeleteFlag { get; set; }
}
