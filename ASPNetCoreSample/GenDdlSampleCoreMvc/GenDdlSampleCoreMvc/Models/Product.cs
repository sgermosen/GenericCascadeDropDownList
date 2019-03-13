using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenDdlSampleCoreMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
