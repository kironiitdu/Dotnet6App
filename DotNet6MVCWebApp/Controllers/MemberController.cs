using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using DotNet6MVCWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class MemberController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;


        public MemberController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _webHostEnviroment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            var members = _context.Members.ToList();
            return View(members);
           
        }

        public async Task<IActionResult> Edit(int memberId)
        {
            var memeber = await _context.Members.FindAsync(memberId); // Getting member by Id from database
            return View(new NewMemberViewModel() { Member = memeber });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberViewModel model, IFormFile photo/*int id, [Bind("MemberId,Name,Gender,DOB,MaritalStatus,Address,PhoneNo,Skills,Hobbies,JobTitle,Technology")] Member member*/)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File not selected");
            }

            var path = Path.Combine(_webHostEnviroment.WebRootPath, "ImageName/Cover", photo.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
                stream.Close();
            }
            model.Member.ImageName = photo.FileName;

            //Finding the member by its Id which we would update
            var objMember = _context.Members.Where(mId => mId.MemberId == model.Member.MemberId).FirstOrDefault();

            if (objMember != null)
            {
                //Update the existing member with new value
                objMember!.Name = model.Member.Name;
                objMember!.Gender = model.Member.Gender;
                objMember!.DOB = DateTime.Now;
                objMember!.ImageName = model.Member.ImageName;
                objMember!.ImageLocation = path;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
    }
}
