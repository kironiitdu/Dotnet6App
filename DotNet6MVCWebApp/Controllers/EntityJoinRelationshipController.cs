using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Controllers
{
    public class EntityJoinRelationshipController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public EntityJoinRelationshipController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            var allEquipmentByDept = _context.Equipment.Include(dept => dept.Department).ToList();
            return View(allEquipmentByDept);
        }

        public IActionResult Create()
        {
            List<SelectListItem> entityTypeList = new List<SelectListItem>();
            entityTypeList.Add(new SelectListItem { Text = "Select Type", Value = "Select Type" });
            entityTypeList.Add(new SelectListItem { Text = "Entity-Type-C#", Value = "Entity-Type-C#" });
            entityTypeList.Add(new SelectListItem { Text = "Entity-Type-SQL", Value = "Entity-Type-SQL" });
            entityTypeList.Add(new SelectListItem { Text = "Entity-Type-Asp.net core", Value = "Entity-Type-Asp.net core" });
            ViewBag.entityType = entityTypeList;
            return View();
        }


        //    [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Amount,Status,DepartmentId,InternalConsigned,entityType,EOLDate")] Equipment equipment)
        // {
            
        //    if (equipment.entityType.Contains("Select Type"))
        //    {
        //        ModelState.AddModelError("", "Entity Type should not be Select Type");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(equipment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
          
        //    return View(equipment);
        //}

        public ActionResult CreateIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Pensionado>> Post([FromBody] Pensionado pensionado)
        {
           // var usuarioId = servicesUsuario.ObtenerUsuarioId();
            var pensionadoBD = new Pensionado
            {
                No_activo = pensionado.No_activo,
                Cobro_indebido = pensionado.Cobro_indebido,
                Clave_pension = pensionado.Clave_pension,
                No_afiliado = pensionado.No_afiliado,
                No_pension = pensionado.No_pension,
                Sexo = pensionado.Sexo,
                ApellidoP = pensionado.ApellidoP,
                ApellidoM = pensionado.ApellidoM,
                Nombre = pensionado.Nombre,
                Fecha_nacimiento = pensionado.Fecha_nacimiento,
                RFC = pensionado.RFC,
                CURP = pensionado.CURP,
               
                Email = pensionado.Email
            };
            //context.Add(pensionadoBD);
            //await context.SaveChangesAsync();
            return pensionado;
        }
    }
    public class Pensionado
    {
        public int Id { get; set; }
        [Required]
        public int No_activo { get; set; }
        public bool Cobro_indebido { get; set; }
        [Required]
        public bool Status_pago { get; set; }
        [Required]
        public int Clave_pension { get; set; }
        [Required]
        public int No_afiliado { get; set; }
        [Required]
        public int No_pension { get; set; }
        [Required]
        public bool Sexo { get; set; }
        [MaxLength(50)]
        [Required]
        public string ApellidoP { get; set; }
        [MaxLength(50)]
        [Required]
        public string ApellidoM { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fecha_nacimiento { get; set; }
        [MaxLength(13)]
        [Required]
        public string RFC { get; set; }
        [MaxLength(18)]
        [Required]
        public string CURP { get; set; }
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }
        public int Estado_civilId { get; set; }
       
    }
}
