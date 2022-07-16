using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet6MVCWebApp.Controllers
{
    public class L_AccessPointController : Controller
    {

        public IActionResult WhenChosen(CharacterViewModel character)
        {
           // var beggarsGuild = _unitOfWork.GuildRepository.GetOneByName("Ankh-Morpork Beggars' Guild").Members.ToList();
          
            var beggar = new Beggar() { Id = 101, BeggarName = "Beggar-101" };
            var charact = new Character() { Id = 101, CharacterName = "Character-101" };
            var guidAndCharacterInfo = new BeggarViewModel() { Beggars = beggar, Characters = charact };
            return View(guidAndCharacterInfo);
        }
        [HttpPost]
        public IActionResult InteractionWithBeggar(CharacterViewModel character, Member member, MemberInfo memberInfo)
        {
            //var _character = character;
            //character.AmountOfTurns++;
            //var beggar = member;
            //var money = character.AmountOfMoney -= memberInfo.AmountOfMoney;

            //if (character.NumberOfRetries > 0 && money > 0)
            //    return RedirectToAction("MainGameplay", "Gameplay", _character);
            //_character.HasWon = false;
            //_character.IsAlive = false;
            return RedirectToAction("WhenChosen", character);
        }
        [HttpPost]
        public IActionResult PlayersDeath(CharacterViewModel character)
        {
            //var _character = character;
            //character.AmountOfTurns++;
            //var beggar = member;
            //var money = character.AmountOfMoney -= memberInfo.AmountOfMoney;

            //if (character.NumberOfRetries > 0 && money > 0)
            //    return RedirectToAction("MainGameplay", "Gameplay", _character);
            //_character.HasWon = false;
            //_character.IsAlive = false;
            return RedirectToAction("WhenChosen", character);
        }
        public IActionResult Index(string stored1s)
        {
          
            if (stored1s != null)
            {
                var stringList = TempData["dados2"].ToString();
                List<Stored1> datosList = JsonConvert.DeserializeObject<List<Stored1>>(stringList);
            }

            

            var listDados = new List<Stored1>()
            {
                new Stored1(){ ap_id = 101,ap_name ="AP-101", year= 2021, DIA=101, MES=202},
                new Stored1(){ ap_id = 102,ap_name ="AP-102", year= 2022, DIA=102, MES=203},
                new Stored1(){ ap_id = 103,ap_name ="AP-103", year= 2023, DIA=103, MES=204},


            };
            var ds = new dadosPassar();
            ds.AcessoVisita = "Initial AcessoVisita";
            ds.tempo = "Initial Tempo";
            ds.ApZona = "Initial Ap Zona";
            ds.Final = DateTime.Now;
            ds.dados2 = listDados;
            return View(ds);
        }

        [HttpPost]
        public ActionResult ExportToexcel_Click([Bind("dados2")] dadosPassar dp)
        {

            var ds = new dadosPassar();
            ds = dp;
            TempData["dados2"] = JsonConvert.SerializeObject(dp.dados2);
            return RedirectToAction("Index");

        }
    }
}
