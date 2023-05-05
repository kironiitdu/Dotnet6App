using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class InstitutionController : Controller
    {
        public IActionResult Index()
        {


            var instituteList = new List<Institution>()
            {
                new Institution(){ Id =101,District = "Dis-A", InstitutionCode = "IC-1",InstitutionName = "IN-AAA",DemolitionStatus="YES",ReinforcementStatus = "T"},
                new Institution(){ Id =102,District = "Dis-B", InstitutionCode = "IC-2",InstitutionName = "IN-BBB",DemolitionStatus="NO",ReinforcementStatus = "F"},
                new Institution(){ Id =103,District = "Dis-C", InstitutionCode = "IC-3",InstitutionName = "IN-CCC",DemolitionStatus="NO",ReinforcementStatus = "T"},
                new Institution(){ Id =104,District = "Dis-D", InstitutionCode = "IC-4",InstitutionName = "IN-DDD",DemolitionStatus="NO",ReinforcementStatus = "T"},
                new Institution(){ Id =105,District = "Dis-E", InstitutionCode = "IC-5",InstitutionName = "IN-EEE",DemolitionStatus="YES",ReinforcementStatus = "T"},
               

            };
            return View(instituteList);
        }
    }
}
