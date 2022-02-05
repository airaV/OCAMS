using OCAMS.Context;
using System.Collections.Generic;

namespace OCAMS.Models.Accounts
{
    public class AccountIndexModel
    {
        public List<OCAMS_AccountLevel> AccountLevels { get; set; }
        public List<OCAMS_AccountType> AccountTypes { get; set; }
        public List<OCAMS_UserType> UserTypes { get; set; }
        public List<AccountsViewModel> AccountsViewModels { get; set; }
    }
}