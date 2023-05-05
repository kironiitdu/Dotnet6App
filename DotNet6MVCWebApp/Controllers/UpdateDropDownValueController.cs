using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet6MVCWebApp.Controllers
{
    public class UpdateDropDownValueController : Controller
    {
        public IActionResult Index()
        {
            List<Game_Type> typeList = new List<Game_Type>();
            typeList.Add(new Game_Type() { Game_Type_ID = 1, Game_Type_Name = "None" });
            typeList.Add(new Game_Type() { Game_Type_ID = 2, Game_Type_Name = "Type A" });
            typeList.Add(new Game_Type() { Game_Type_ID = 3, Game_Type_Name = "Type B" });
            typeList.Add(new Game_Type() { Game_Type_ID = 4, Game_Type_Name = "Type C" });
            typeList.Add(new Game_Type() { Game_Type_ID = 5, Game_Type_Name = "Type D" });

            List<Game> gameList = new List<Game>();
            gameList.Add(new Game() { Game_ID = 1, Game_Name = "Name A", Game_Type_List = new SelectList(typeList, "Game_Type_ID", "Game_Type_Name", "1") });
            gameList.Add(new Game() { Game_ID = 2, Game_Name = "Name B", Game_Type_List = new SelectList(typeList, "Game_Type_ID", "Game_Type_Name", "2") });
            gameList.Add(new Game() { Game_ID = 3, Game_Name = "Name C", Game_Type_List = new SelectList(typeList, "Game_Type_ID", "Game_Type_Name", "3") });


            return View(gameList);
           
        }
    }
    public class Game_Type
    {
        public int Game_Type_ID { get; set; }
        public string Game_Type_Name { get; set; }
    }

    public class Game
    {
        public int Game_ID { get; set; }
        public int Game_Type_ID { get; set; }
        public string Game_Name { get; set; }
        public SelectList Game_Type_List { get; set; }
    }
}
