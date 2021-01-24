using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            ApplicationUserRole = new HashSet<ApplicationUserRole>();
        }
        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
