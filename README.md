# GenericCascadeDropDownList

See the Spanish Version of this article on my blog: https://www.sgermosen.com/2019/03/creando-un-dropdownlist-en-cascada.html

This is a jQuery Generic ddl to populate data from Side A to Side B, without have a distinct implementation for each one.

Inspired by the tutorials of the great educator Juan Carlos Zuluaga, motivate me to write an article on how to create (or use) a cascaded Dropdownlist, I mean, the data that exists on a B side (as a city) depends on the data selected in side A (as country).

While it is true that making a Ddl in cascade is something so simple, it is still true that the duplication of code is something that lately concerns more than the account to companies, who choose a programmer for their technical knowledge, but likewise, they prefer that this technical knowledge be optimized.

That's why I've decided to explain the way I've done it, of course there may be other ways, but, this is the simplest I've seen so far, because when I did it, I really did it with very basic knowledge of c #, so this is what guarantees that it's done by a novice for newbies: D

# How to use it on Dot Net Core

Let's start
The first thing we are going to do is create 3 models
Country => City => Client 

public class Country
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Denomym { get; set; } 
    public ICollection&lt;City&gt; Cities { get; set; }
}
public class City
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Denomym { get; set; } 
    public Country Country { get; set; } 
    public ICollection&lt;Client&gt; Clients { get; set; }
}
public class Client
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Lastname { get; set; } 
    public City City { get; set; } 
}

The idea is that when choose a country it should filter and bring me the cities of it.

After that, we must create a ViewModel that hosts the data of the Client model, and to which we will complement the data that does not have the same, in my particular case, I always prefer to put it to inherit from the base class, and complete those that are missing, but in this example I will do it as simple as possible. (You could see on my xample project, the way that i done).

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
    public ICollection&lt;Country&gt; Country { get; set; }
    //This is added to receive the Listed items
    public IEnumerable&lt;SelectListItem&gt; Cities { get; set; }
    public IEnumerable&lt;SelectListItem&gt; Countries { get; set; }
 
}

We create a Helper to convert any entity to a SelectListItem, this is not necessary, but it is a way to avoid duplication of code and more when this is something that normally does not change.

public class GenericSelectList
{
    public IEnumerable&lt;SelectListItem&gt; CreateSelectList&lt;T&gt;(IList&lt;T&gt; entities, Func&lt;T, object&gt; funcToGetValue, Func&lt;T, object&gt; funcToGetText)
    {
        return entities
            .Select(x =&gt; new SelectListItem
            {
                Value = funcToGetValue(x).ToString(),
                Text = funcToGetText(x).ToString()
            });
    }
}

Now is the time to create our method that is going to take of bringing our data, I personally put it in the controller that is going to take charge of manipulating our information, but it can perfectly be put in a Helper. in this case, keep it simple.

public JsonResult GetCitiesFromCountry(int id)
 {
     var dbList = _context.Cities.Where(m =&gt; m.Country.Id == id)
         .Select(c =&gt; new
         {
             Id = c.Id,
             Name = c.Name
         });
 
     return Json(dbList);
 }

Then we created the control that was responsible for bringing our data to send it to the view and after that obtain the data, convert it to send it to the database.For obvious reasons here I will not use patterns or anything like that, because the only interest is to explain the generic Js file to fill a cascading ddl.

public class ClientsController : Controller
  {
      private readonly AppContext _context;
      private readonly GenericSelectList _genericSelectList;
      
      public ClientsController(AppContext context)
      {
          _context = context;
          _genericSelectList = new GenericSelectList();
      }
     
       public async Task&lt;IActionResult&gt; Create()
      {
          var countries = new List&lt;Country&gt;
          {
              new Country
              {
                  Id = 0,
                  Name = "Choose one Country"
              }
          };
       
          countries.AddRange(await _context.Countries.ToListAsync());       
          var model = new ClientViewModel
          {
              Countries = _genericSelectList.CreateSelectList(countries, x =&gt; x.Id, x =&gt; x.Name),
          }; 
          return View(model);
      }
 
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task&lt;IActionResult&gt; Create(ClientViewModel model)
      {
          if (ModelState.IsValid)
          {
              var city = await _context.Cities.FindAsync(model.CityId); 
              var client = new Client
              {
                  Name = model.Name,
                  Lastname = model.Lastname,
                  City = city
              }; 
              _context.Add(client);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }
          return View(model);
      }
  }
  
We create the view and reference the script on our page, and create a variable using javascript called "gUrlDdl" to which we must assign the url where is the method that brings the data, do not forget to assign the Master class the class " MasterDdl "and detail" DetailDdl "



@model GenDdlSampleCoreMvc.Models.ClientViewModel
 
&lt;div class="row"&gt;
    &lt;div class="col-md-4"&gt;
        &lt;form asp-action="Create"&gt;
            &lt;div asp-validation-summary="ModelOnly" class="text-danger"&gt;&lt;/div&gt;
 
            &lt;div class="form-group"&gt;
                &lt;label asp-for="Country" class="control-label"&gt;&lt;/label&gt;
                &lt;select asp-for="CountryId" 
                        asp-items="Model.Countries"
                        class="form-control MasterDdl"&gt;
                &lt;/select&gt;
                &lt;span asp-validation-for="Country" class="text-danger"&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div class="form-group"&gt;
                &lt;label asp-for="City" class="control-label"&gt;&lt;/label&gt;
                &lt;select asp-for="CityId" 
                        asp-items="Model.Cities" 
                        class="form-control DetailDdl"&gt;                
                &lt;/select&gt;
                &lt;span asp-validation-for="City" class="text-danger"&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div class="form-group"&gt;
                &lt;label asp-for="Name" class="control-label"&gt;&lt;/label&gt;
                &lt;input asp-for="Name" class="form-control" /&gt;
                &lt;span asp-validation-for="Name" class="text-danger"&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div class="form-group"&gt;
                &lt;label asp-for="Lastname" class="control-label"&gt;&lt;/label&gt;
                &lt;input asp-for="Lastname" class="form-control" /&gt;
                &lt;span asp-validation-for="Lastname" class="text-danger"&gt;&lt;/span&gt;
            &lt;/div&gt;
            &lt;div class="form-group"&gt;
                &lt;input type="submit" value="Create" class="btn btn-primary" /&gt;
            &lt;/div&gt;
        &lt;/form&gt;
    &lt;/div&gt;
&lt;/div&gt;
&lt;script src="~/lib/sGenCascadeDdl/dist/sgencascadeddl.js"&gt;&lt;/script&gt;
 
&lt;script&gt;
         var gUrlDdl = '@Url.Action("GetCitiesFromCountry", "Clients")';
&lt;/script&gt;



And voila, we already have everything we need for our Cascade Dropdown List
