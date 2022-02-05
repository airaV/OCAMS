using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class UserModel
    {
        public long Id { get; set; }
        public long? PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long? UserTypeId { get; set; }
        public bool? IsOTPEnable { get; set; }
        public bool? IsActive { get; set; }

    }
}