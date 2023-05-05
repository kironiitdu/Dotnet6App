using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext db;

        public PatientsController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public ActionResult GetAllPatients()
        {
            var patients = db.Patients.ToList();
            return View(patients);
        }
    }
}
