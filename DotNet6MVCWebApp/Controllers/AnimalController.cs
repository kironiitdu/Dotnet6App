using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public AnimalController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public async Task<string> File([FromForm] CreateAnimalViewModel model)
        {
            string wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, "Images", model.Photo!.FileName);
            if (model.Photo.Length > 0)
            {
                using var stream = new FileStream(path, FileMode.Create);
                await model.Photo.CopyToAsync(stream);
            }
            return model.Animal!.PhotoUrl = model.Photo.FileName;
        }



        public async Task<int> AddAnimal(Animal animal)
        {
            _context.Add(animal!);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAnimal(Animal animal)
        {
            _context.Update(animal);
            return await _context.SaveChangesAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMember(MemberViewModel model, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File not selected");
            }
            var path = Path.Combine(_environment.WebRootPath, "ImageName/Cover", photo.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
                stream.Close();
            }

            model.Member.ImageName = photo.FileName;

            if (model == null)
            {
                return Content("Invalid Submission!");
            }
            var member = new Member
            {
                Name = model.Member.Name,
                Gender = model.Member.Gender,
                DOB = model.Member.DOB,
                ImageName = model.Member.ImageName,
                ImageLocation = path,
            };
            _context.Add(member);
            await _context.SaveChangesAsync();
            return RedirectToAction("MemberList");

        }
        public IActionResult CreateMemberView()
        {

            return View();
        }

        public IActionResult ViewUser(string Identifier)
        {
            
            return View();
        }
        public IActionResult MemberList(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var members = from mem in _context.Members
                          select mem;
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.Name.ToLower().Contains(searchString.ToLower())
                                       || m.Gender.ToLower().Contains(searchString.ToLower()));
                return View(members);
            }
            TempData["Identifier"] = "Kiron";
            var memberList = _context.Members.ToList();
            return View(memberList);

        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMember(MemberViewModel model, IFormFile photo)
        {
            string? memberPhotoName = "";
            string? path = "";
            bool isOldUpload = true;

            if (photo == null || photo.Length == 0)
            {
                //If Current Upload Is Empty then find by the member Id if previously upload any picture
                memberPhotoName = _context.Members.Where(mId => mId.MemberId == model.Member.MemberId).Select(pic => pic.ImageName).FirstOrDefault();
                if (memberPhotoName != null)
                {
                    isOldUpload = false;
                }
                if (string.IsNullOrEmpty(memberPhotoName))
                {
                    return Content("File not selected");
                }

            }

            //Save The Picture In folder
            if (isOldUpload)
            {
                path = Path.Combine(_environment.WebRootPath, "ImageName/Cover", photo.FileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                    stream.Close();
                }
            }

            try
            {
                var photoName = photo.FileName;
                if (photoName != null)
                {
                    model.Member.ImageName = photo.FileName;
                }

            }
            catch (NullReferenceException err)
            {
                model.Member.ImageName = memberPhotoName;
                path = Path.Combine(_environment.WebRootPath, "ImageName/Cover", memberPhotoName);
                var fileNameFromPath = System.IO.Path.GetFileName(path);
            }


            //Finding the member by its Id which we would update
            var objMember = _context.Members.Where(mId => mId.MemberId == model.Member.MemberId).FirstOrDefault();

            if (objMember != null)
            {
                //Update the existing member with new value
                objMember!.Name = model.Member.Name;
                objMember!.Gender = model.Member.Gender;
                objMember!.DOB = model.Member.DOB;
                objMember!.ImageName = model.Member.ImageName;
                objMember!.ImageLocation = path;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("MemberList");


        }

        /*

    ============
    Algorithm
    ============
    1.From The Member List Click On Perticular Member Id
    2.Find The Member Information By that Id
    3.Load The Edit Page Same As Create Member Page
    4.After Required Chnage Submit the Edit Page Which Containing the Member Mdoel Data With A ID
    5.Save the Image Into Folder First Same As Create
    6.Search The Member Object By Id
    7.Set New Value Into The Member Object You Have Founded In Step 6
    8.Save The Context And Redirect To Member List
*/
        public async Task<IActionResult> EditMember(int memberId)
        {



            var memeber = await _context.Members.FindAsync(memberId); // Getting member by Id from database
            return View(new MemberViewModel() { Member = memeber });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnimal(CreateAnimalViewModel model, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File not selected");
            }
            var path = Path.Combine(_environment.WebRootPath, "images", photo.FileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
                stream.Close();
            }

            model.Animal!.PhotoUrl = model.Photo!.FileName;


            // Find the existing data
            var objAnimal = _context.Animals.Where(aId => aId.AnimalId == model.Animal.AnimalId).FirstOrDefault();

            DateTime localDateTimeInputByUser = DateTime.Now;

            DateTime utcDateTime = localDateTimeInputByUser.ToUniversalTime();


            if (model != null)
            {
                //Update the date with new value
                objAnimal!.AnimalId = model.Animal.AnimalId;
                objAnimal.Name = model.Animal.Name;
                objAnimal.Category = model.Animal.Category;
                objAnimal.Description = model.Animal.Description;
                objAnimal.PhotoUrl = model.Animal.PhotoUrl;
                objAnimal.LocalTime = DateTime.Now.ToString();
                objAnimal.UTCTime = DateTime.UtcNow.ToString();
                objAnimal.AzureTime = DateTime.UtcNow.ToString();
                _context.SaveChanges();
            }


            return RedirectToAction("Edit", new { id = model!.Animal.AnimalId });

        }
        public async Task<IActionResult> Edit(int id)
        {



            var animal = await _context.Animals.FindAsync(id); // Getting Time From Azure 
            var azureTime = Convert.ToDateTime(animal!.AzureTime); // Because I have save date time as string
            var convertedToLocalTime = azureTime.ToLocalTime(); // Local Time

            // ViewBag.Category = new SelectList(_repository.GetCategoriesTable(), "CategoryId", "Name");
            return View(new CreateAnimalViewModel() { Animal = animal, DisplayPhoto = animal!.PhotoUrl, ImageURL = animal!.PhotoUrl });
            //  return View(animal);
        }

        public IActionResult Index()
        {
            var animal = _context.Animals.ToList();
            return View(animal);
        }
    }


}
