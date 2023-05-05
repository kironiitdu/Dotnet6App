using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageDemoApp.Pages
{
    public class InsertMultipleRowsModel : PageModel
    {
        [BindProperty]
        public InvRow InvRow { get; set; }
        public IList<InvRow> RowList { get; set; }
        public IActionResult OnGetAsync()
        {

            var rr = new List<InvRow>()
        {
            new InvRow() { Name = "Apple", Qty = 1, Price = 100 },
             new InvRow() { Name = "Peach", Qty = 1, Price = 500 },
              new InvRow() { Name = "Ananas", Qty = 1, Price = 1100 },
        };

            RowList = rr;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(IList<InvRow> RowList)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //_context.InvRows.AddRange(rw);

            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }

    public class InvRow
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}
