using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace DotNet6MVCWebApp.Controllers
{
    public class SelectListViewModelController : Controller
    {
        public static List<Roles> listOfRoles = new List<Roles>()
        {
            new Roles() { RoleId =101, RoleName ="Admin", },
            new Roles() { RoleId =102, RoleName ="Dev", },
            new Roles() { RoleId =103, RoleName ="QA", },
            new Roles() { RoleId =104, RoleName ="Tester", },
        };
        public static List<NewDepartment> listOfDept = new List<NewDepartment>()
        {
            new NewDepartment() { DepartmentId =201, DepartmentName ="RND", },
            new NewDepartment() { DepartmentId =202, DepartmentName ="Dev", },
            new NewDepartment() { DepartmentId =203, DepartmentName ="Support", },
            new NewDepartment() { DepartmentId =204, DepartmentName ="HR", },
        };
        public IActionResult Index()
        {
            NewRoleVM roleVMObj = new NewRoleVM();
            roleVMObj.RoleList = listOfRoles.Select(
                    i => new SelectListItem
                    {
                        Text = i.RoleName,
                        Value = i.RoleId.ToString()
                    }
                ).ToList();
            roleVMObj.DepartmentList = listOfDept.Select(
                    i => new SelectListItem
                    {
                        Text = i.DepartmentName,
                        Value = i.DepartmentId.ToString()
                    }
                ).ToList();
            roleVMObj.RoleOpenning = new RoleOpennings();
            return View(roleVMObj);
        }
        [HttpGet]
        //[Authorize(Roles = "Manager")]
        public IActionResult CreateNew()
        {
            NewRoleVM roleVMObj = new NewRoleVM();
            roleVMObj.RoleList = listOfRoles.Select(
                    i => new SelectListItem
                    {
                        Text = i.RoleName,
                        Value = i.RoleId.ToString()
                    }
                ).ToList();
            roleVMObj.DepartmentList = listOfDept.Select(
                    i => new SelectListItem
                    {
                        Text = i.DepartmentName,
                        Value = i.DepartmentId.ToString()
                    }
                ).ToList();
            roleVMObj.RoleOpenning = new RoleOpennings();
            return View(roleVMObj);
        }

        [HttpPost]
       
        public IActionResult CreateNew(NewRoleVM roleVMObj)
        {
            //if (_signInManager.IsSignedIn(User))
            //{
            //    roleVMObj.RoleOpenning.Published = true;
            //    if (!ModelState.IsValid)
            //    {
            //        return View(roleVMObj);
            //    }
            //    _db.RoleOpennings.Add(roleVMObj.RoleOpenning);
            //    _db.SaveChanges();
            //}

            return RedirectToAction("Index");
        }
    }

    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class NewDepartment
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    
    public class RoleOpennings
    {
        public int Id { get; set; }


        [Required]
        [DisplayName("Role Name")]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Roles Roles { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public NewDepartment Department { get; set; }

        public int EditorId { get; set; }
        [ForeignKey(nameof(EditorId))]
      //  public StaffPersonalDetails staffPersonalDetails { get; set; }


        [DisplayName("Opening Date")]
        public DateOnly? OpeningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [DisplayName("Closing Date")]
        public DateOnly? CloseDate { get; set; }

        public bool Published { get; set; } = false;

        public bool IsClosed { get; set; } = false;

        [Required]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }

    public class NewRoleVM
    {
        public RoleOpennings RoleOpenning { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }

        public List<SelectListItem> RoleList { get; set; }
    }
}
