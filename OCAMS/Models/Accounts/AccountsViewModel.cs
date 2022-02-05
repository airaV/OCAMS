using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class AccountsViewModel
    {
        public string Fullname { get; set; }
        public string LevelName { get; set; }
        public string CurrencyName { get; set; }
        public AccountsModel Account { get; set; }
        public PersonModel Person { get; set; }
        public UserModel User { get; set; }
    }


}