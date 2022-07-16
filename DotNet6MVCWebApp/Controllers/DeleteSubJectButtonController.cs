using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{



    public class DeleteSubJectButtonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public DeleteSubJectButtonController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public static List<Subject> ListOfSubject = new List<Subject>()
        {
            new Subject() { SubId =1, SubName ="XYZ", },
            new Subject() { SubId =2, SubName ="PQR", },
            new Subject() { SubId =3, SubName ="ABC", },
            new Subject() { SubId =4, SubName ="TTR", },
            new Subject() { SubId =5, SubName ="HGF", }
        };
        public static List<Student> ListOfStudent = new List<Student>()
        {

            new Student() { StuId =1, SubId ="4", StuName = "STU1" },
            new Student() { StuId =2, SubId ="4", StuName = "STU2" },
            new Student() { StuId =3, SubId ="4", StuName = "STU3" },
            new Student() { StuId =4, SubId ="2", StuName = "STU4" },
            new Student() { StuId =5, SubId ="1", StuName = "STU5" },


        };

        public IActionResult Index()
        {
            /*
                      ============
                       Algorithm
                      ============
                      1.Find the list Of subject where student has no enrolment 
                      2.Loop over the list of subject and check which subject has no enrolment
                      3.Set "no enrolment" to a new ViewModel and Build new List
                      4.Get the new list of enrolment status and set button into it 
                      5.Repeat 1 to 4 

            
            /*
                    ================
                     Implementation
                    ================
            */


            //1.Find the list Of subject where student has no enrolment 
            var subThatStudentDont = ListOfSubject.Where(stu => ListOfStudent.All(sub => sub.SubId.ToString() != stu.SubId.ToString()));

            //Building new viewModel for Final output
            List<StudentSubjectViewModel> viewModelList = new List<StudentSubjectViewModel>();

            //2.Loop over the list of subject and check which subject has no enrolment
            foreach (var item in ListOfSubject)
            {
                var studentSubjectViewModel = new StudentSubjectViewModel
                {
                    SubId = item.SubId,
                    SubName = item.SubName,
                    IsDelete = subThatStudentDont.Any(x => x.SubId == item.SubId) ? true : false //3.Set "no enrolment" to a new ViewModel and Build new List
                };
                //5.Repeat 1 to 4 
                viewModelList.Add(studentSubjectViewModel);
            };





            return View(viewModelList);
        }

        public IActionResult Delete(string subId)
        {
            //Will Delete following id from database

            return RedirectToAction("Index");
        }


        public class Subject
        {
            public int SubId { get; set; }
            public string SubName { get; set; }


        }

        public class Student
        {
            public int StuId { get; set; }
            public string StuName { get; set; }
            public string SubId { get; set; }


        }
    }
}
