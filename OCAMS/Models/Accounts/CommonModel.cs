using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCAMS.Models.Accounts
{
    public partial class CommonModel
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}