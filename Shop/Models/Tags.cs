using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneMobile { get; set; }
        public int VenderId { get; set; }
        public Vender Vender { get; set; }
    }
}
