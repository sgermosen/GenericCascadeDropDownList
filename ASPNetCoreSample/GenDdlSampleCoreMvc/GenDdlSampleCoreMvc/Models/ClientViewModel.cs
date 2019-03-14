using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenDdlSampleCoreMvc.Models
{
    public class ClientViewModel : Client
    {
        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a City.")]
        public int CityId { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a City.")]
        public int CountryId { get; set; }

        public ICollection<Country> Country { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

    }
}
