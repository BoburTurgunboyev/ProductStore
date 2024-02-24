using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
