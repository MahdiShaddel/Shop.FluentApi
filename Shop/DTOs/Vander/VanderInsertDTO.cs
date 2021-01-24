using System;
using System.Collections.Generic;
using Shop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DTOs.Vander
{
    public class VanderInsertDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Models.Tags>  Tags { get; set; }
    }
}
