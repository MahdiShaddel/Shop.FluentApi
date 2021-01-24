using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DTOs.Vander
{
    public class VanderListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }
    }
}
