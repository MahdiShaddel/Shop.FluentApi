using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
