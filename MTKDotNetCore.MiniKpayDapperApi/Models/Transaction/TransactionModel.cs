﻿namespace MTKDotNetCore.MiniKpayDapperApi.Models.Transaction
{
    public class TransactionModel
    {
        public int Transaction_Id {  get; set; }
        public string FromPhoneNumber { get; set; }
        public string ToPhoneNumber { get; set; }
        public decimal Amount { get; set; }
        public string Pin { get; set; }
        public bool DeleteFlag {  get; set; }
        public DateTime Created_Date { get; set; }

    }
}