using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CansInnov.Shared
{
    public class UserInfo
    {
        public static readonly UserInfo Anonymous = new UserInfo();

        public bool IsAuthenticated { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string UserName { get { return GivenName + " " + SurName; } }
        public string UserMail { get; set; }
        public string UserMatricule { get; set; }
        public string NameClaimType { get; set; }
        public string RoleClaimType { get; set; }
        public ICollection<ClaimValue> Claims { get; set; }
    }
}