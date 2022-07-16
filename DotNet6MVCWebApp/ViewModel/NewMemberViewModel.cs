using DotNet6MVCWebApp.Models;

namespace DotNet6MVCWebApp.ViewModel
{
    public class NewMemberViewModel
    {
        public Member Member { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
