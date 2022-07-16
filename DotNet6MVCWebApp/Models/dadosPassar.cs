using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Models
{
    public class dadosPassar
    {
     
        public List<Stored1> dados2 { get; set; }
        //public List<L_AccessPoint>? Aps { get; set; } = new List<L_AccessPoint>();
        //public List<L_Zone>? Zones { get; set; } = new List<L_Zone>();
        //public List<int>? ap { get; set; }
        public DateTime Inicial { get; set; }
        public DateTime Final { get; set; }
        public string? AcessoVisita { get; set; }
        public string? tempo { get; set; }
        public string ApZona { get; set; }
    }
}
