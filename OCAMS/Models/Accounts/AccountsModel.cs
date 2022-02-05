using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class AccountsModel : CommonModel
    {
        public long Id { get; set; }
        public long? PersonId { get; set; }
        public long? UserId { get; set; }
        public long? AccountLevelId { get; set; }
        public long? AccountTypeId { get; set; }
        public decimal? CreditLimit { get; set; }
        public long? CurrencyId { get; set; }
        public decimal? CasinoBalance { get; set; }
        public decimal? TotalCasinoBalance { get; set; }
        public int? Commission { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? Withdrawal { get; set; }
        public bool? IsActive { get; set; }
        public string IsActiveDescription { get; set; }
    }
}