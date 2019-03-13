namespace GenDdlSampleFrameworkMvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public string Denomym { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}