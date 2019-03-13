namespace GenDdlSampleFrameworkMvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string ClientName { get; set; }

        public int CityId { get; set; }

        public string Destination { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}