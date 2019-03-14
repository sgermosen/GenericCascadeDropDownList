using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GenDdlSampleCoreMvc.Models
{
    public class ClientViewModel //: Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public City City { get; set; }

        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a City.")]
        public int CityId { get; set; }

        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Country.")]
        public int CountryId { get; set; }
        //This is added because I dont want to save country on client, but I need on the ViewModel
        public ICollection<Country> Country { get; set; }
        //This is added to receive the Listed items
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

    }
}
