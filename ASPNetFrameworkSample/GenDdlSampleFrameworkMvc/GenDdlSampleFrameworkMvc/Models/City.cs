namespace GenDdlSampleFrameworkMvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }

        public string Denomym { get; set; }

        public  int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}