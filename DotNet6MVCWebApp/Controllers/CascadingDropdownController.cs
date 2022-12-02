using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class CascadingDropdownController : Controller
    {
        
        public static List<Country> ListOfCountry = new List<Country>()
        {
            new Country() { CountryId =101, CountryName ="INDIA", },
            new Country() { CountryId =102, CountryName ="USA", }, 
            new Country() { CountryId =103, CountryName ="UK", },
            new Country() { CountryId =104, CountryName ="Canada", },
        };

        public static List<ProductCategorie> ListOfProductCategory = new List<ProductCategorie>()
        {
            new ProductCategorie() { ProductCategorieId =101, ProductCategorieName ="Backend", },
            new ProductCategorie() { ProductCategorieId =102, ProductCategorieName ="Frontend", },
            new ProductCategorie() { ProductCategorieId =103, ProductCategorieName ="Database", }
        };
        public static List<ProductSubCategorie> ListOfSubCategorie = new List<ProductSubCategorie>()
        {
            //Backend
            new ProductSubCategorie() { ProductCategorieId =101, ProductSubCategorieId =1, ProductSubCategorieName = "C#" },
            new ProductSubCategorie() { ProductCategorieId =101, ProductSubCategorieId =2, ProductSubCategorieName = "Java" },
            new ProductSubCategorie() { ProductCategorieId =101, ProductSubCategorieId =3, ProductSubCategorieName = "Python" }, 
            //Frontend
            new ProductSubCategorie() { ProductCategorieId =102, ProductSubCategorieId =4, ProductSubCategorieName = "Javascript" },
            new ProductSubCategorie() { ProductCategorieId =102, ProductSubCategorieId =5, ProductSubCategorieName = "React" },
            new ProductSubCategorie() { ProductCategorieId =102, ProductSubCategorieId =6, ProductSubCategorieName = "Angular" },
            //Database
            new ProductSubCategorie() { ProductCategorieId =103, ProductSubCategorieId =7, ProductSubCategorieName = "SQL Server" },
            new ProductSubCategorie() { ProductCategorieId =103, ProductSubCategorieId =8, ProductSubCategorieName = "My SQL" },
            new ProductSubCategorie() { ProductCategorieId =103, ProductSubCategorieId =9, ProductSubCategorieName = "Postgres SQL" },
        };
        public static List<State> ListOfState = new List<State>()
        {
            //INDIA
            new State() { CountryId =101, StateId =1, StateName = "Delhi" }, 
            new State() { CountryId =101, StateId =2, StateName = "Haydrabad" }, 
            new State() { CountryId =101, StateId =3, StateName = "Pune" }, 
            //USA
            new State() { CountryId =102, StateId =4, StateName = "New York" },
            new State() { CountryId =102, StateId =5, StateName = "Silicon Valley" },
            new State() { CountryId =102, StateId =6, StateName = "Dallaus" },
            //UK
            new State() { CountryId =103, StateId =7, StateName = "London" },
            new State() { CountryId =103, StateId =8, StateName = "Cardif" },
            new State() { CountryId =103, StateId =9, StateName = "Sundarland" },
             //Candada
            new State() { CountryId =104, StateId =10, StateName = "Alberta" },
            new State() { CountryId =104, StateId =11, StateName = "Ontario" },
            new State() { CountryId =104, StateId =12, StateName = "Manitoba" },
        };
        public static List<District> ListOfDistrict = new List<District>()
        {
            //INDIA
            new District() { DistrictId =101, StateId =1, DistrictName = "District Of Delhi" },
            new District() { DistrictId =101, StateId =2, DistrictName = "District Of Haydrabad" },
            new District() { DistrictId =101, StateId =3, DistrictName = "District Of Pune" }, 
            //USA
            new District() { DistrictId =102, StateId =4, DistrictName = "District Of New York" },
            new District() { DistrictId =102, StateId =5, DistrictName = "District Of Silicon Valley" },
            new District() { DistrictId =102, StateId =6, DistrictName = "District Of Dallaus" },
            //UK
            new District() { DistrictId =103, StateId =7, DistrictName = "District Of London" },
            new District() { DistrictId =103, StateId =8, DistrictName = "District Of Cardif" },
            new District() { DistrictId =103, StateId =9, DistrictName = "District Of Sundarland" },
        };
        


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexProduct()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> LoadCategory()
        {
            var productCategories =  ListOfProductCategory.ToList();

            return Ok(productCategories);

        }
        [HttpGet]
        public async Task<ActionResult> GetSubCategory(int productCategorieId)
        {
            var subCategories = ListOfSubCategorie.Where(cId => cId.ProductCategorieId == productCategorieId).ToList();

            return Ok(subCategories);

        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory(SubmitModel model)
        {

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> LoadCountry()
        {
            var country = ListOfCountry.ToList();
            
            return Ok(country);
           
        }

        [HttpGet]
        public async Task<ActionResult> GetState(int countryId)
        {
            var state = ListOfState.Where(cId => cId.CountryId == countryId).ToList() ;

            return Ok(state);

        }
        [HttpGet]
        public async Task<ActionResult> GetStateByCountryName(string countryName)
        {
            int getCountryId = ListOfCountry.Where(name => name.CountryName == countryName).Select(id => id.CountryId).FirstOrDefault();
            var state = ListOfState.Where(cId => cId.CountryId == getCountryId).ToList();

            return Ok(state);

        }

        [HttpGet]
        public async Task<ActionResult> GetDistrict(int stateId)
        {
            var state = ListOfDistrict.Where(cId => cId.StateId == stateId).ToList();

            return Ok(state);

        }


        [HttpPost]
        public async Task<IActionResult> AddCountryStateDistrict(SubmitModel model)
        {
           
            return RedirectToAction("Index");
        }
    }

    public class ProductCategorie
    {
        public int ProductCategorieId { get; set; }
        public string? ProductCategorieName { get; set; }
    }
    public class ProductSubCategorie
    {
        public int ProductSubCategorieId { get; set; }
        public string? ProductSubCategorieName { get; set; }
        public int ProductCategorieId { get; set; }
    }
    public class Country
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int StateId { get; set; }
    }

    public class SubmitModel
    {
        public int ddlCountry { get; set; }
        public int ddlState { get; set; }
        public int ddlDistrict { get; set; }
      
    }
}
