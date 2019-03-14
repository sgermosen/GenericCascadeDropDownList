using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenDdlSampleCoreMvc.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public City City { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
