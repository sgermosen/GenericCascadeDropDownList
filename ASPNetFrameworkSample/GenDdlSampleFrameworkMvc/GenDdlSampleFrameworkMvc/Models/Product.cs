namespace GenDdlSampleFrameworkMvc.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public  int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}