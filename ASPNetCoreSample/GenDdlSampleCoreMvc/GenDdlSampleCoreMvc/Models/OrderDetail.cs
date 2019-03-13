using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenDdlSampleCoreMvc.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }



    }
}
