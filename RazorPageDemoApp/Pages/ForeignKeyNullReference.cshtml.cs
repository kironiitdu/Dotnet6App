using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoApp.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageDemoApp.Pages
{
    public class ForeignKeyNullReferenceModel : PageModel
    {
        private readonly AppDbContext _db;

        public Client Client { get; set; }
        public Shot Shot { get; set; }


        public ForeignKeyNullReferenceModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int Id)
        {
            Client = _db.Clients
                    .Include(client => client.Shots).FirstOrDefault(client => client.ClientId == Id);
        }
    }



    public class Client
    {
        [Key]
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }

        public List<Shot>? Shots { get; set; }

        [Required]
        [Display(Name = "Client No (###)")]
        public string? ClientNo { get; set; }

        [Required]
        [Display(Name = "Incident No")]
        public string? IncidentNo { get; set; }
    }
    public class Shot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ShotId { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        [Required]
        [Display(Name = "Incident No")]
        public string? IncidentNo { get; set; }

        [Required]
        [Display(Name = "Client No")]
        public string? ClientNo { get; set; }
    }
}
