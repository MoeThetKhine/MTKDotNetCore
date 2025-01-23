namespace MTKDotNetCore.MiniKpay.Database.Models.User;

#region User Response Model

public class UserResponseModel
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Balance { get; set; }
    public string Pin { get; set; }
    public string Password { get; set; }
}

#endregion