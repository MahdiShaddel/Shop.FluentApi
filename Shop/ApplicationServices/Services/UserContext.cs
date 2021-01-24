using Shop.Host.ApplicationServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.ApplicationServices.Services
{
    public class UserContext : IUserContext
    {
        public string UserId { get; set; }
    }
}
