using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Models
{
    public class IdentityProfilePicController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public IdentityProfilePicController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ActionResult Index()
        {
            InputModel model = new InputModel();
            return View(model);
        }

        public ActionResult IdentityProfilePicList()
        {
            var memberList = _context.identityModels.ToList();
            return View(memberList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIdentityProfilePic(InputModel model, IFormFile profilePicture)
        {
            if (profilePicture == null || profilePicture.Length == 0)
            {
                return Content("File not selected");
            }
            var path = Path.Combine(_environment.WebRootPath, "ImageName/Cover", profilePicture.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await profilePicture.CopyToAsync(stream);
                stream.Close();
            }



            if (model == null)
            {
                return Content("Invalid Submission!");
            }
            var identityModel = new IdentityModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                ImageName = profilePicture.FileName,
                ProfilePictureLocation = path,
              
            };
            _context.Add(identityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("IdentityProfilePicList");

        }
    }
}
