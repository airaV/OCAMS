using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class AccountLevelModel : CommonModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}