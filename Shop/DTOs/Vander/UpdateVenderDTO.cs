using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DTOs.Vander
{
    public class UpdateVenderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Models.Tags> Tags { get; set; }
    }
}
