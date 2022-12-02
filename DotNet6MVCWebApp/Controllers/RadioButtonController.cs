using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class RadioButtonController : Controller
    {
        public IActionResult Index()
        {
            var radioButtonList = new List<RadioButtonTestModel>()
            {
                new RadioButtonTestModel() { ItemID=1,ItemName="apple", IsAvailable = true },
                new RadioButtonTestModel() { ItemID=2,ItemName="mango", IsAvailable = false },
                new RadioButtonTestModel() { ItemID=3,ItemName="stuck", IsAvailable = false },
                new RadioButtonTestModel() { ItemID=4,ItemName="blocked", IsAvailable = false },
                new RadioButtonTestModel() { ItemID=5,ItemName="help:(", IsAvailable = false },


            };

            var model = new RaidioButtonFromViewBagModel();
            model.RadioButtons = radioButtonList;
            return View(model);
          
        }
        [HttpPost]
        public IActionResult SubmitValueFromCheckBoxList(RadioButtonTestModel checkBoxViewModel)
        {
            var checkBoxValueFromView = checkBoxViewModel;
            return Ok(checkBoxValueFromView);
        }

        
    }
}
