using Microsoft.EntityFrameworkCore;
using Shop.Context;
using Shop.Host.Inferastructure.IRepositories;
using Shop.Host.Models.Identity;
using System.Linq;

namespace Shop.Host.Inferastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ShopContext _context;

        public ApplicationUserRepository(ShopContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserWithRolesByUserId(string UserId)
        {
            return _context.Users.Where(x => x.Id == UserId).Include(ur => ur.UserRoles).ThenInclude(r=>r.Role).FirstOrDefault();
        }
    }
}
