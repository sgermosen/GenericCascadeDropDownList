namespace GenDdlSampleFrameworkMvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}