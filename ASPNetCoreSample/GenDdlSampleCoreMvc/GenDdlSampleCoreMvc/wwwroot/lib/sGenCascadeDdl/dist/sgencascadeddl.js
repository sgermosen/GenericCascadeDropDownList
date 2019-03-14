//Actual Mode of work with this

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
        //        public JsonResult GetProductsFromCategory(int id)
        //{
        //    var dbList = _context.Products.Where(m => m.Category.Id == id)
        //        .Select(c => new
        //            {
        //                Id = c.Id,
        //                Name = c.Name
        //            });
        //    return Json(dbList);
        //}

//2. Reference the JS on your view,
//  <script src="~/lib/sGenCascadeDdl/dist/sgencascadeddl.js"></script>

//3. Populate data from controller to a viewbag to part A (master or masters), you could check the controller file on this dist
        //var countries = _context.Countries.OrderBy(p => p.Name).ToList();
        //ViewBag.Countries = countries;
////this initialization is not neccesary, you can set on the client
        //var cities = new List < City >
        //    {
        //        new City { Id = 0, Name = "-- Choose a city --" }
        //            };
        //ViewBag.Cities = cities;
        //var categories = _context.Categories.OrderBy(p => p.Name).ToList();
        //ViewBag.Categories = categories;
////this initialization is not neccesary, you can set on the client
        //var product = new List < Product >
        //    {
        //        new Product { Id = 0, Name = "-- Choose a product --" }
        //            };
        //ViewBag.Products = product;

//4. Receive the data from viewbag on your view
        //var countries = ViewBag.Countries;
        //var cities = ViewBag.Cities;
        //var category = ViewBag.Categories;
        //var product = ViewBag.Products;
//5. Add the class element to the master "MasterDdl" and to the details "DetailDdl"






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
