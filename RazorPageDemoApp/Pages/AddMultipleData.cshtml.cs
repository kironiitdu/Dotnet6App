using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDemoApp.Data;
using RazorPageDemoApp.Models;

namespace RazorPageDemoApp.Pages
{
    public class AddMultipleDataModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddMultipleDataModel(AppDbContext context)
        {
            _context = context;
        }
       
        public List<ClientService> clientServices { get; set; }
        public void OnGet()
        {
            var clientServiceList = new List<ClientService>()
            {
                new ClientService(){ CliId ="CliId:1",ServId = "ServId-A",Active = false},
                new ClientService(){ CliId ="CliId:2",ServId = "ServId-B",Active = false},
                new ClientService(){ CliId ="CliId:3",ServId = "ServId-C",Active = true},
                new ClientService(){ CliId ="CliId:4",ServId = "ServId-D",Active = true},
                new ClientService(){ CliId ="CliId:5",ServId = "ServId-E",Active = false},
               
            };
            clientServices = clientServiceList;

        }
       
        public async Task<IActionResult> OnPostAsync(List<ClientService> clientServices)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return Page();
                //}

                _context.clientServices.AddRange(clientServices);

                await _context.SaveChangesAsync();

                return RedirectToPage("./AddMultipleData");
            }
            catch (Exception e)
            {
                e.ToString();
                return RedirectToPage("./Index");
            }
        }
    }
}
