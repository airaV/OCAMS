using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}