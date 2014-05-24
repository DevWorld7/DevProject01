using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nickron.Database
{
    public class UserSession
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? LoggedInTime { get; set; }
    }
}
