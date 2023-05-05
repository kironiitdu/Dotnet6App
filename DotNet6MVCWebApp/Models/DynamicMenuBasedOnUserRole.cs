using Microsoft.Graph;

namespace DotNet6MVCWebApp.Models
{
    public class DynamicMenuBasedOnUserRole
    {
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public bool IsVisible { get; set; }
        public string? Role { get; set; }
    }
}
