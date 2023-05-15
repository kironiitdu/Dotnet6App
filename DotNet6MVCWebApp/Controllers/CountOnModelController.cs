using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class CountOnModelController : Controller
    {
        public IActionResult Index()
        {
            var countCheckModel = new List<HMOPremisesViewModel>
            {

                new HMOPremisesViewModel(){ PremisesID = new Guid(), PremiseNickname = "Microsoft",ApplicationType = "A", ApplicationID ="101",TaskType =1},
                new HMOPremisesViewModel(){ PremisesID = new Guid(), PremiseNickname = "Amazon",ApplicationType = "B", ApplicationID ="201",TaskType =2},
                new HMOPremisesViewModel(){ PremisesID = new Guid(), PremiseNickname = "Google",ApplicationType = "C", ApplicationID ="303",TaskType =2},
            };

            var emptyList = new List<HMOPremisesViewModel>();
            return View(countCheckModel);
        }
        [HttpPost]
        public ActionResult PostRadioBUtton(List<RadioButtonModel> radioButtonModels)
        {
            return Ok(radioButtonModels);
        }
    }
    public class RadioButtonModel
    {
     
        public string Name { get; set; }
        public string Value { get; set; }
        public string Id { get; set; }
        public bool IsChecked { get; set; }
    }
    public class HMOPremisesViewModel
    {
        public Guid PremisesID { get; set; }
        public string PremiseNickname { get; set; }
        public string ApplicationType { get; set; }
        public string ApplicationID { get; set; }
        public int TaskType { get; set; }
    }
}
