using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorPageDemoApp.Models;
using System.Transactions;

namespace RazorPageDemoApp.Pages
{
    public class ViewUploadModel : PageModel
    {
       // public BankscrapeDbContext BankscrapeDbContext { get; }

        [BindProperty]
        public List<UploadTransaction> UploadTransactions { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        //public ViewUploadModel(BankscrapeDbContext bankscrapeDbContext)
        //{
        //    BankscrapeDbContext = bankscrapeDbContext;
        //}

        public void OnGet()
        {
            Transactions = JsonConvert.DeserializeObject<List<Transaction>>(this.HttpContext.Session.GetString("UploadTransactions"));
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
