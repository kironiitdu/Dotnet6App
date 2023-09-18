using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Xml.Serialization;

namespace DotNet6MVCWebApp.Controllers
{
    public class YonnyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public YonnyController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {

            var fruitsList_1 = new List<Fruit>()
            {
                new Fruit(){ Id =101,Color = "Banana-Yellow", Taste = "Sweet"},
                new Fruit(){Id = 102,Color = "Berry-Black", Taste = "Sour"},
                new Fruit(){ Id =103,Color = "Mango-Yellow", Taste = "Sweet"},

            };
            var fruitsList_2 = new List<Fruit>()
            {
                new Fruit(){ Id =201,Color = "PineApple-Yellow", Taste = "Sweet-Sour"},
                new Fruit(){Id = 202,Color = "Apple-While", Taste = "Sweet"},
                new Fruit(){ Id =203,Color = "Orange-Yellow", Taste = "Sour"},

            };

            var fruitsList_3 = new List<Fruit>()
            {
                new Fruit(){ Id =301,Color = "PineApple-Yellow", Taste = "Sweet-Sour"},
                new Fruit(){Id = 302,Color = "Apple-While", Taste = "Sweet"},
                new Fruit(){ Id =303,Color = "Orange-Yellow", Taste = "Sour"},

            };
            var basketsList = new List<Basket>()
            {
                new Basket(){ Id = 401,Sharp  ="Sharp-A",Material  ="Material-X", Fruits = fruitsList_1},
                new Basket(){ Id = 402,Sharp  ="Sharp-B",Material  ="Material-Y", Fruits = fruitsList_2},
                new Basket(){ Id = 403,Sharp  ="Sharp-C",Material  ="Material-Z", Fruits = fruitsList_3 }

            };


            return View();
        }
        [HttpPost]
        public IActionResult FakeMethod(FakeModel fakeModel)
        {
            var vName = fakeModel.NewName;
            return RedirectToAction("Home", "Home");
        }

       
        public IActionResult DownloadFile(int newSerialNumber)
        {
            return View();
        }
        public IActionResult SaveIndex()
        {
            var demoList = new List<DemoModelClass>()
            {
                new DemoModelClass(){ newSerialNumber = 1001,ecuType  ="ecuType-A",exp  ="exp-X", ecuSft = "ecuSft-P"},
                new DemoModelClass(){ newSerialNumber = 1002,ecuType  ="ecuType-B",exp  ="exp-Y", ecuSft = "ecuSft-Q"},
                new DemoModelClass(){ newSerialNumber = 1003,ecuType  ="ecuType-C",exp  ="exp-Z", ecuSft = "ecuSft-R" }

            };
            return View(demoList);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Basket model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Content("Invalid Submission!");
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
     [Bind("Id,Material,Sharp,Fruits")] DotNet6MVCWebApp.Models.Basket basket)
        {
            if (ModelState.IsValid)
            {
                //Save Basket
                _context.Add(basket);
                await _context.SaveChangesAsync();

                //Add Fruits List
                foreach (var item in basket.Fruits)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Create));
            }
            return View(basket);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Produces("application/xml")]
        [Consumes("application/xml")]
        public async Task<ActionResult> ParseXmlObjectToClass()
        {
            string xml;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(Request.Body, Encoding.UTF8))
            {
                xml = await reader.ReadToEndAsync();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(NewDataSet));
            using (TextReader reader = new StringReader(xml))
            {
                List<NewDataSet> result = (List<NewDataSet>)serializer.Deserialize(reader);
                return Ok(result);

            }


        }


    }


    public class DemoModelClass
    {
        public string ecuType { get; set; }
        public string exp { get; set; }
        public string ecuSft { get; set; }
        public int newSerialNumber { get; set; }
    }

    public class FakeModel
    {
        public string NewName { get; set; }
    }
    public class QuarterlyNonComplianceReportDTO
    {
    }


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class NewDataSet
    {

        private NewDataSetTable[] tableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Table")]
        public NewDataSetTable[] Table
        {
            get
            {
                return this.tableField;
            }
            set
            {
                this.tableField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class NewDataSetTable
    {

        private string nameField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }


}
