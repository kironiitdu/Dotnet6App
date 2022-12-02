using DocumentFormat.OpenXml.InkML;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using System.Text;
using System.Xml;


namespace DotNet6MVCWebApp.Controllers
{
    public class TeamController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public TeamController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var members = from mem in _context.Teams
                          select mem;
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.TeamName.ToLower().Contains(searchString.ToLower())
                                       || m.TeamName.ToLower().Contains(searchString.ToLower()));
                return View(members);
            }

            var teamList = _context.Teams.Include(tm => tm.TeamMembers).ToList();
            return View(teamList);
        }

        public IActionResult Create()
        {
            Team team = new Team();
            team.TeamMembers.Add(new TeamMember() { TeamMemberId = 1 });
            return PartialView("_AddTeamPartialView", team);
        }


        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team != null)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult PartialModalFocus()
        {
            return View();
        }
        public async Task<object> PostXMLRequestAspNet5API()
        {

            try
            {
                //Console.WriteLine("Exemplo ticketBai");
                var handler = new HttpClientHandler();
                //handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                //handler.SslProtocols = SslProtocols.Tls12;
                //handler.ClientCertificates.Add(new X509Certificate2("Certificado", "Password"));
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(handler);

                string xmlString = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"> <soapenv:Header/> <soapenv:Body> <PaymentNotificationRequest> <User>USER</User> <Password>pass</Password> <HashVal>NzIwNGE3MzI5YmU5MTg3ZTUwZTQ1YmRjMjA0NDc2MjUyODQ2MmQ1ODIwZTIyYzNkNDk0NTBjNjUwZTgwYmM2Yw==</HashVal> <TransType>999</TransType> <TransID>FTC221024YAWQ</TransID> <TransTime>2210241702</TransTime> <TransAmount>1.00</TransAmount> <AccountNr>6592460859</AccountNr> <Narrative>Test</Narrative> <PhoneNr>66666</PhoneNr> <CustomerName>Customer 1</CustomerName> <Status>SUCCESS</Status> </PaymentNotificationRequest> </soapenv:Body> </soapenv:Envelope>";

                var httpContent = new StringContent(xmlString, Encoding.UTF8, "application/xml");
                client.DefaultRequestHeaders.Accept.Clear();

                var VResultado = await client.PostAsync("http://localhost:4400/home/PostAsync", httpContent);
                if (VResultado.IsSuccessStatusCode == false)
                {
                    return null;
                }
                else
                {
                    //Aceptado no necesaria verificacion
                    var data = await VResultado.Content.ReadAsStringAsync();
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(data);
                    XmlNodeList nodeList = xmldoc.GetElementsByTagName("string");
                    string response = string.Empty;
                    foreach (XmlNode node in nodeList)
                    {
                        response = node.InnerText;
                    }
                    Console.WriteLine(response);
                    return response;
                    //}
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
