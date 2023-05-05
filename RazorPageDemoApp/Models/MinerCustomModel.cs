using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoApp.Models
{
    public class MinerCustomModel
    {

        public string? PowerSerialNumber { get; set; }
        public string? MinerSerialNumber { get; set; }
        public string? WorkerName { get; set; }
    }
}
