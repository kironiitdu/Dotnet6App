using System.ComponentModel.DataAnnotations;

namespace DotNet6MVCWebApp.Models
{
    public class UserLog
    {
        [Key]
        public Int64 ulogo_id { get; set; }
        public string login_time {get; set; }
        public string controller { get; set; }
        public string http_verb { get; set; }
        public string page_name { get; set; }
    }
}
