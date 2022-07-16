using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet6App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            var roleList = new List<Role>()
            {
                new Role(){ Id = 1,Name ="Plan A", Description= "Plan Description A", Date=DateTime.Now,Deleted= true},
                new Role(){ Id = 2,Name ="Plan B", Description= "Plan Description B", Date=DateTime.Now,Deleted= false},
                new Role(){ Id = 3,Name ="Plan C", Description= "Plan Description C", Date=DateTime.Now,Deleted= true},
                new Role(){ Id = 4,Name ="Plan D", Description= "Plan Description D", Date=DateTime.Now,Deleted= false},
                new Role(){ Id = 5,Name ="Plan E", Description= "Plan Description E", Date=DateTime.Now,Deleted= true},


            };
             return roleList;
        }

        //[HttpGet]
        //public IActionResult GetRole()
        //{
        //    var roleList = new List<Role>()
        //    {
        //        new Role(){ Id = 1,Name ="Plan A", Description= "Plan Description A", Date=DateTime.Now,Deleted= true},
        //        new Role(){ Id = 2,Name ="Plan B", Description= "Plan Description B", Date=DateTime.Now,Deleted= false},
        //        new Role(){ Id = 3,Name ="Plan C", Description= "Plan Description C", Date=DateTime.Now,Deleted= true},
        //        new Role(){ Id = 4,Name ="Plan D", Description= "Plan Description D", Date=DateTime.Now,Deleted= false},
        //        new Role(){ Id = 5,Name ="Plan E", Description= "Plan Description E", Date=DateTime.Now,Deleted= true},
              

        //    };
        //    return Ok(roleList);
        //}
    }
}
