namespace sGenCascadeDdl.dist
{
    using System.Collections.Generic;

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Denomym { get; set; }

        public Country Country { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
