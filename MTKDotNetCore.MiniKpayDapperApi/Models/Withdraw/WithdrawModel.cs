﻿namespace MTKDotNetCore.MiniKpayDapperApi.Models.Withdraw;

#region WithdrawModel

public class WithdrawModel
{
    public int Withdraw_Id { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Balance { get; set; }
    public bool DeleteFlag { get; set; }
}

#endregion