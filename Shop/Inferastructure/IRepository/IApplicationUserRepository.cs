using Shop.Host.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.Inferastructure.IRepositories
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUserWithRolesByUserId(string UserId);
    }
}
