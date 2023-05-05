using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebAPIApp.Data;
using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IWebHostEnvironment _environment;


        //public LoginController(IWebHostEnvironment environment, ApplicationDbContext context)
        //{
        //    _environment = environment;
        //    _context = context;
        //}
        //[AllowAnonymous]
        //[HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(string userName, string password)
        //{

        //    if (userName == null || password == null)
        //    {
        //        return BadRequest();
        //    }

        //    var getUserInfo = _context.User.Where(uname => uname.Email == userName);

        //    return Ok(getUserInfo);
        //}

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
