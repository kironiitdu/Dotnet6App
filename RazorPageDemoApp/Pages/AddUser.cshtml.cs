using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageDemoApp.Data;
using System.ComponentModel.DataAnnotations;

namespace RazorPageDemoApp.Pages
{
    public class AddUserModel : PageModel
    {
        [BindProperty]
        public AddUserViewModel userModel { get; set; }
        private readonly AppDbContext _db;
        public AddUserModel(AppDbContext db)
        {
            _db = db;
            userModel = new AddUserViewModel();
        }
        public void OnGet()
        {
            userModel.Branches = _db.Branches.ToList();
            ViewData["Branches"] = new SelectList(_db.Branches.ToList(), "iBranchCode", "vBranchDesc");                                      //userModel.Branches have 81 rows
        }
    }

    public class AddUserViewModel
    {

        public int SelectedBranchId { get; set; }
        public List<Branch> Branches { get; set; }
    }
    public class Branch
    {
        [Key]
        public string iBranchCode { get; set; }
        public string vBranchDesc { get; set; }
    }
}
