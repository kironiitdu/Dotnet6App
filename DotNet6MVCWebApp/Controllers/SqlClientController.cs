using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DotNet6MVCWebApp.Controllers
{
    public class SqlClientController : Controller
    {

        [HttpGet]
        public JsonResult search()
        {
           

            string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
            List<string> listData = new List<string>();
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT [CountryName] FROM [WsAttendance].[dbo].[Country]", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        // # I have problem in this loop **

                        while (reader.Read())
                        {
                          
                           string countryNamee = reader.GetString(0);
                            listData.Add(countryNamee);
                        }

                    }
                    return Json(listData);
                }
            }
        }



    }
}
