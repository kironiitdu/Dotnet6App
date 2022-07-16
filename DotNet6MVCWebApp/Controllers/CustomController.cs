using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet6MVCWebApp.Controllers
{
    [JsonObject]
    public abstract class CustomController : Controller
    {

        abstract public string Title { get; set; }
        abstract public string TitleDescription { get; set; }
    }
}
