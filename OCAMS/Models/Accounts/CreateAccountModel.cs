using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class CreateAccountModel
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long? AccountLevelId { get; set; }
        public long? AccountTypeId { get; set; }
        public decimal? CreditLimit { get; set; }
        public long? CurrencyId { get; set; }
        public decimal? CasinoBalance { get; set; }
        public decimal? TotalCasinoBalance { get; set; }
        public int? Commission { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? Withdrawal { get; set; }
    }
}