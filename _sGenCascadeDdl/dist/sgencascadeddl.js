//////////////////////////////////////////////////////////////
//Author:       Starling Germosen Reynoso
//Social Media: www.fb.com/sgermosen24, www.fb.com/xamarindo
//Website:      www.praysoft.net
//GitHub:       Github.com/sgermosen
/////////////////////////////////////////////////////////////

//Actual Mode of work with this o netCore

//0. Create the models, you could check the ones than are on the this dist
//    public class Country {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Denomym { get; set; }
//        public ICollection < City > Cities { get; set; }
//    }
//    public class City {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Denomym { get; set; }
//        public Country Country { get; set; }
//        public ICollection < Client > Clients { get; set; }
//    }
//    public class Client {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Lastname { get; set; }
//        public City City { get; set; }
//    }
//0.1 Create the ViewModel
//    public class ClientViewModel : Client
//    {
//              [Display(Name = "City")]
//              [Range(1, int.MaxValue, ErrorMessage = "You must select a City.")]
//              public int CityId { get; set; }

//              [Display(Name = "Country")]
//              [Range(1, int.MaxValue, ErrorMessage = "You must select a City.")]
//              public int CountryId { get; set; }

//              public ICollection < Country > Country { get; set; }
//              public IEnumerable < SelectListItem > Cities { get; set; }
//              public IEnumerable < SelectListItem > Countries { get; set; }
//    }
//0.2 Create the View

//1. Create your returning method where you are going to get your data and convert it to json, you can create it on a controller
//   or in a separate class, maybe on your "Helper" folder, you could check the helper folder on this dist
    //public JsonResult GetCitiesFromCountry(int id)
    //{
    //    var dbList = _context.Cities.Where(m => m.Country.Id == id)
    //        .Select(c => new
    //            {
    //                Id = c.Id,
    //                Name = c.Name
    //            });
    //    return Json(dbList);
    //}

//2. Reference the JS on your view,
//  <script src="~/lib/sGenCascadeDdl/dist/sgencascadeddl.js"></script>

//3. Create a Generic SelectListItem, this is not mandatory, but it simplyfied the things when you have to work with DDL on web
//, you could check the one that I create for you on the "Helper" Folder with this "dist"
    //public IEnumerable < SelectListItem > CreateSelectList<T>(IList < T > entities, Func < T, object > funcToGetValue, Func < T, object > funcToGetText)
    //{
    //    return entities
    //        .Select(x => new SelectListItem
    //                {
    //                Value = funcToGetValue(x).ToString(),
    //                Text = funcToGetText(x).ToString()
    //            });
    //}

//4. Populate initial Data from controller to part A (master or masters), you could check the controller file on this dist
    //var countries = 
    //new List < Country >
    //      {
    //        new Country{  Id = 0,
    //                      Name = "Choose one Country"
    //                   }
    //      };

    //countries.AddRange(await _context.Countries.ToListAsync());
    //var model = new ClientViewModel
    //{
    //    Countries = _genericSelectList.CreateSelectList(countries, x => x.Id, x => x.Name)
    //};
////or you could make it more direct, but, in this case, I prefeer populate the default value (choose one) 
////on the controller and not in the client, this is the not recommended way, neither is shorten
                    //var countries = await _context.Countries.ToListAsync();
                    //var model = new ClientViewModel
                    //{
                    //    Countries = _genericSelectList.CreateSelectList(countries, x => x.Id, x => x.Name)
                    //};

//5. Receive the data on your view and set the class "MasterDdl & DetailDdl
    //<div class="form-group">
    //    <label asp-for="Country" class="control-label"></label>
    //    <select asp-for="CountryId" asp-items="Model.Countries" class="form-control MasterDdl"></select>
    //    <span asp-validation-for="Country" class="text-danger"></span>
    //</div>
    //<div class="form-group">
    //    <label asp-for="City" class="control-label"></label>
    //    <select asp-for="CityId" asp-items="Model.Cities" class="form-control DetailDdl"></select>
    //    <span asp-validation-for="City" class="text-danger"></span>
    //</div>
//6. Open a Script Section to declareted the Url, where it is gonna search the data (Point 1)
//  <script type="text/javascript">
//      var gUrlDdl = '@Url.Action("GetCitiesFromCountry", "Clients")';
//  </script >
//7. Enjoy it

//////////////////////////////////////////////////////



//_Legacy Mode
//1. Create a class with the value Id, and Name, Copy the estructure of the C# file on "dist" folder
//    public class GenericList 
//    {
//    public int Id { get; set; }
//    public string Name { get; set; }
//    }
//2. Create your returning method where you are going to get your data and convert it to json, you can create it on a controller
//   or in a separate class, maybe on your "Helper" Folder, you could check the helper folder on this dist
//public async Task<JsonResult> GetLabPosibleResults(int id)
//{
//    _db.Configuration.ProxyCreationEnabled = false;
//    var dbList = _db.LaboratoryDetails.Where(m => m.LaboratoryId == id);
////or
//    var dbList = await  _db.LaboratoryDetails.Where(m => m.LaboratoryId == id).ToListAsync;
//    var rtList = new List<GenericList>();
//    foreach(var item in dbList)
//    {
//        var element = new GenericList
//        {
//            Id = item.LaboratoryDetailId,
//            Name = item.Result
//        };
//        rtList.Add(element);
//    }
//    return Json(rtList);
//}
//3. Reference the JS on your view,
//  <script src="~/lib/sGenCascadeDdl/dist/sgencascadeddl.js"></script>
//4. If you want, fill with initial values your original list
//var myFilledList = _db.Laboratories.Where(p => p.AuthorId == autorid).OrderBy(p => p.Name).ToList();
//ViewBag.Products = myFilledList;

//var myEmptyList = new List < Doctor >
//{
//    new Doctor { DoctorId = 0, Name = "-- Seleccione un Doctor" }
//};
//ViewBag.Doctors = myEmptyList;
//5. Receive on your view
//var myFilledList = ViewBag.Products;
//var myEmptyList = ViewBag.Doctors
//6. Add the class element to the master "MasterDdl" and to the details "DetailDdl"
//   @Html.DropDownList("NameOfMaster", new SelectList(myFilledList, "Id", "Name"), "-- Seleccione una Prueba --", new { @class = "form-control MasterDdl" })
//   @Html.DropDownList("NameOfDetail", new SelectList(myEmptyList, "Id", "Name"), "-- Seleccione un Resultado --", new { @class = "form-control DetailDdl" })
//or if you are using razor
//   @Html.DropDownList("Products", null, htmlAttributes: new { @class = "form-control MasterDdl" })
//   @Html.DropDownList("Doctors", null, htmlAttributes: new { @class = "form-control DetailDdl" })
//7. Open a Script Section to declareted the Url, where it is gonna search the data (Point 2)
//  <script type="text/javascript">
//      var gUrlDdl = '@Url.Action("GetLabPosibleResults", "Laboratories")';
//  </script >
//8. Enjoy it


//Starling Germosen Reynoso www.fb.com/sgermosen24, www.fb.com/xamarindo, www.praysoft.net

$(document).ready(function () {
    $(".MasterDdl").change(function () {
        //clean the populated data on the detail dropdownlist
        $(".DetailDdl").empty();
        $.ajax({
            type: "POST",
            url: gUrlDdl,
            dataType: "json",
            data: { id: $(".MasterDdl").val() },
            success: function (list) {
                $.each(list,
                    function (i, item) {
                        $(".DetailDdl").append('<option value="' + item.id + '">' + item.name + "</option>");
                    });
            },
            error: function (ex) {
                alert("Error trying load data." + ex);
            }
        });
        return false;
    });
});
