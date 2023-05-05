using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DotNet6MVCWebApp.Controllers
{
    public class ModelBindingComplexObjectController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CheckRouteValueInValidator([FromRoute] TestVM toDoList)
        {
            return Ok(toDoList);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Priority,AssignToId,AssignTo, Status")] ToDoList toDoList)
        {



            if (ModelState.IsValid)
            {
                //_context.Add(toDoList);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }

            //ViewData["AssignToId"] = new SelectList(_context.Members, "Id", "Id", toDoList.AssignToId);
            return View(toDoList);
        }


        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModelState user)
        {

            //List<OrganisationUserVariables> listOfUserVariable = new List<OrganisationUserVariables>();
            //listOfUserVariable.Add(new OrganisationUserVariables() { VariableId = 101, OrganisationId = 201, Id = 301,CertificateId=401,OrganisationUser ="A" });
            //listOfUserVariable.Add(new OrganisationUserVariables() { VariableId = 102, OrganisationId = 202, Id = 302,CertificateId=402, OrganisationUser = "B" });
            //listOfUserVariable.Add(new OrganisationUserVariables() { VariableId = 103, OrganisationId = 203, Id = 303,CertificateId=403, OrganisationUser = "C" });
            //listOfUserVariable.Add(new OrganisationUserVariables() { VariableId = 104, OrganisationId = 204, Id = 304,CertificateId=404, OrganisationUser = "D" });



            //var VariableCount = listOfUserVariable

            //   .Where(OUV => OUV.VariableId == 1
            //     //Problem line
            //     && (OUV.OrganisationUser.OrganisationUserCertificates
            //         .Any(cv => cv.CertificateId == C.Id))
            //     && (OUV.OrganisationUser.OrganisationId == user.OrganisationId))
            //    .Count();


            List<Genre> listofGenres = new List<Genre>();
            listofGenres.Add( new Genre() { Id=1,GenreName="Action"});
            listofGenres.Add( new Genre() { Id=2,GenreName="Thriller"});
            listofGenres.Add( new Genre() { Id=3,GenreName="Comedy"});

            List<Movie> listofmovies= new List<Movie>();
            listofmovies.Add(new Movie() { Id = 1, MovieName = "Terminator",Genres ="" });
            listofmovies.Add(new Movie() { Id = 2, MovieName = "Green Mile",Genres="" });
            listofmovies.Add(new Movie() { Id = 3, MovieName = "Catch me if you can",Genres="" });

          //  var movies = listofmovies.Where(p => p.Genres.Intersect(listofGenres).Any());
            if (ModelState.IsValid)
            {
               
            }

            
            return View("CreateUser");
        }
    }

    public class Movie
    {
        public int Id { get; set; }     
        public string MovieName { get; set; }
        public string Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
    }


    public partial class OrganisationUserVariables
    {
        public int VariableId { get; set; }
        public int OrganisationId { get; set; }
        public int Id { get; set; }
        public int CertificateId { get; set; }
        public string OrganisationUser { get; set; }
    }
    public partial class UserModelState
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Login { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!; // (actually it's not encrypted yet)

       
    }
    public class ToDoList
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "To Do List Item cannot be longer than 200 characters.")]
        public string Title { get; set; }
      //  [CustomValidator]
        public string Description { get; set; } = null;

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }


        public string Priority { get; set; } = null!;

        public int AssignToId { get; set; }


        public MemberClass AssignTo { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [RegularExpression("^(Completed|Not Completed)$", ErrorMessage = "The status must be Completed or Not Completed")]
        public string Status { get; set; }

    }

    public class TestVM
    {

        public string Id { get; set; }
        [CustomValidator]
        public string name { get; set; }
    }

    public class MemberClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Required]
        public ICollection<ToDoList> ToDoLists { get; set; }


    }

    public class CustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var vm = context.ObjectInstance as TestVM;

           // var httpContextAccessor = (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor));
            var httpContextAccessor = context.GetRequiredService<IHttpContextAccessor>();

            var getIdFromRouteValue = httpContextAccessor.HttpContext.Request.Query["Id"];
            var getNameFromRouteValue = httpContextAccessor.HttpContext.Request.Query["name"];

            vm.Id = getIdFromRouteValue;
            vm.name = getNameFromRouteValue;
            return ValidationResult.Success;


        }
    }

}
