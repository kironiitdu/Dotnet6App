using DotNet6MVCWebApp.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.ViewModel
{
    public class RoleOpenningsDashboardVM
    {
        public RoleOpennings RoleOpenning { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }

        public List<SelectListItem> RoleList { get; set; }
    }
}
