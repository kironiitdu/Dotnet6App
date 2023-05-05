using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using DotNet6MVCWebApp.Data;
using AspNetCore;

namespace DotNet6MVCWebApp.Controllers
{
    public class AutoFillController : Controller
    {
        private readonly ApplicationDbContext _context;



        public AutoFillController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(string identificacion)
        {
            var sutdent = _context.Solicituds.Where(s => s.Identificacion == identificacion).DefaultIfEmpty();
            return Ok(sutdent);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchStudent(string identificacion)
        {

            Solicitud solicitud = new Solicitud();

            string cs = "Server=WX-6899;Database=WsAttendance;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection con = new SqlConnection(cs);
            var command = con.CreateCommand();
            command.CommandText = string.Format("SELECT Id,Identificacion, Nombre, Apellido FROM Solicitud WHERE Identificacion = '{0}'", identificacion);
           

            con.Open();
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                solicitud.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                solicitud.Identificacion = dr.GetValue(1).ToString();
                solicitud.Nombre = dr.GetValue(2).ToString();
                solicitud.Apellido = dr.GetValue(3).ToString();
            }



            con.Close();
            return Ok(solicitud);



        }
    }


    public class Solicitud
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Numero")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El identificacion del estudiante es obligatorio")]
        [DisplayName("Nombre del estudiante")]
        public String? Identificacion { get; set; } // ID of student

        [Required(ErrorMessage = "El nombre del estudiante es obligatorio")]
        [DisplayName("Nombre del estudiante")]
        public String? Nombre { get; set; } // Name of student

        [Required(ErrorMessage = "El apellido del estudiante es obligatorio")]
        [DisplayName("Apellido del estudiante")]
        public String? Apellido { get; set; } // Last name of student
    }
}
