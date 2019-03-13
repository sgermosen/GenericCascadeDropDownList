namespace GenDdlSampleCoreMvc.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Denomym { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
