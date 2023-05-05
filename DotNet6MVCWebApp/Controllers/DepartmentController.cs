using DocumentFormat.OpenXml.Bibliography;
using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using NuGet.Versioning;
using System.Data.Entity;

namespace DotNet6MVCWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public DepartmentController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public ActionResult GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetailsList = new List<OrderDetail>()
            {
                new OrderDetail(){ OrderId =101,VendorId =201, IsActive = 1,Quantity = 10},
                new OrderDetail(){ OrderId =101,VendorId =301, IsActive = 0,Quantity = 10},
                new OrderDetail(){ OrderId =101,VendorId =404, IsActive = 1,Quantity = 25},
                new OrderDetail(){ OrderId =102,VendorId = 202,IsActive = 0,Quantity = 15},
                new OrderDetail(){ OrderId =103,VendorId = 203,IsActive =1,Quantity = 20},

            };

            var listOfOD = orderDetailsList.Where(x => x.OrderId == orderId && x.IsActive == 1).OrderBy(x => x.VendorId).ToList();
            return Ok(listOfOD);
        }
        public IActionResult Index()
        {

            var clientList = new List<Client>()
            {
                new Client(){ ClientId =101,Name = "Client-A",Address = "CAN-Ontaria"},
                new Client(){ ClientId =102,Name = "Client-B",Address = "CAN-Alberta"},
                new Client(){ ClientId =103,Name = "Client-C",Address = "US-Silicon Valley"},

            };

            var projectList = new List<Project>()
            {
                new Project(){ ProjectId =301,Name = "Pro-A",Technology = "C#",ClientId =101},
                new Project(){ ProjectId =302,Name = "Pro-B",Technology = "Asp.net core",ClientId =101 },
                new Project(){ ProjectId =303,Name = "Pro-C",Technology = "Web API",ClientId =102},

            };

            //Way One
            List<Client> unmatchedResult = clientList
                .ExceptBy(projectList.Select(nonExist => nonExist.ClientId), nonExist => nonExist.ClientId)
                .ToList();

            //Way Two
            var findUnmatched = from clienet in clientList
                                where !(from project in projectList select project.ClientId)
                                .Contains(clienet.ClientId)
                                select clienet;

            return View();
        }

        
    }
   
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int VendorId { get; set; }
        public int IsActive { get; set; }
        public int Quantity { get; set; }
    }
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Technology { get; set; }
        public int ClientId { get; set; }
    }
}
