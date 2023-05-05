using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Models
{
    public class ServerNames
    {
        [Key]
        public int ServerID { get; set; }
        public string Server_Name { get; set; }
        public string Server_Type { get; set; }
        public string Operating_System { get; set; }
        public string Version { get; set; }
        public bool IsActive { get; set; }  
    }
}
