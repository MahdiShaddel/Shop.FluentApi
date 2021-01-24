using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Host.ApplicationServices.IServices
{
    public interface IUserContext
    {
        public string UserId { get; set; }
    }
}
