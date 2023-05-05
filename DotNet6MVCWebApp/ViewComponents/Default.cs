using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.ViewComponents
{
   [ViewComponent(Name = "Default")]
    public class Default : ViewComponent
    {
        public IViewComponentResult Invoke(DisclosureCardViewModel disclosureCardViewModel) =>
    View(disclosureCardViewModel);
    }

    
}
