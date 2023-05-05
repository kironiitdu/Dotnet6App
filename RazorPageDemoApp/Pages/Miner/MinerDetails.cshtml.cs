using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPageDemoApp.Models;

namespace RazorPageDemoApp.Pages.Miner
{
    public class MinerDetailsModel : PageModel
    {
        [BindProperty]
        public MinerCustomModel? minerCustomModel { get; set; } = new MinerCustomModel();


        //public void OnGet(string objectData)
        //{
        //    var stringObj = TempData["DataKey"].ToString();

        //   // var enitity222 = System.Text.Json.JsonSerializer.Deserialize<MinerCustomModel>(objectData);
        //    var enitity = System.Text.Json.JsonSerializer.Deserialize<MinerCustomModel>(objectData);

        //    minerCustomModel.PowerSerialNumber = enitity.PowerSerialNumber;
        //    minerCustomModel.MinerSerialNumber = enitity.MinerSerialNumber;
        //    minerCustomModel.WorkerName = enitity.WorkerName;


        //}
        public void OnGet()
        {

        }
    }
}
