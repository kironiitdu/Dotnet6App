using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class CheckboxSelectedValueController : Controller
    {
        public IActionResult Index()
        {
            var combatantVirtualList = new List<Combatant>()
            {
                new Combatant() { ID=1,CombatantName="Combatant-A", IsChecked = false },
                new Combatant() { ID=2,CombatantName="Combatant-B", IsChecked = false },
                new Combatant() { ID=3,CombatantName="Combatant-C", IsChecked = false },
                new Combatant() { ID=4,CombatantName="Combatant-D", IsChecked = false },
                new Combatant() { ID=5,CombatantName="Combatant-E", IsChecked = false },


            };

            var model = new CombatantViewModel();
            model.Combatants = combatantVirtualList;
            return View(model);
            
        }

        [HttpPost]
        public IActionResult SubmitCombatantSelectedValue(CombatantViewModel combatantViewModel)
        {
            var combatantSelectedValueFromView = combatantViewModel.Combatants?.Where(ifSelected=> ifSelected.IsChecked == true).ToList();

            return Ok(combatantSelectedValueFromView);
        }
    }

    public class Combatant
    {
        public int ID { get; set; }
        public string? CombatantName { get; set; }
        public bool IsChecked { get; set; }
    }

    public class CombatantViewModel
    {
        public List<Combatant>? Combatants { get; set; }
    }
}
