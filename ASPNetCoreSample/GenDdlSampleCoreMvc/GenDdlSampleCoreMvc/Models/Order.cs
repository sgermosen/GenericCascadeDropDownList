namespace GenDdlSampleCoreMvc.Models
{
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public string ClientName { get; set; }           

        public string Destination { get; set; }

        public City City { get; set; }

        public  ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
