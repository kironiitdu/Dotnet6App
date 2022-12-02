using DocumentFormat.OpenXml.Office2010.Excel;
using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DotNet6MVCWebApp.Controllers
{
    public class AdoDotNetUserUpdate : Controller
    {
        List<UserInfo> ListUsers = new List<UserInfo>();
        UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public IActionResult Index()
        {
          
            string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM userCaseSO";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserInfo userInfo = new UserInfo();
                            userInfo.id = "" + reader.GetInt32(0);
                            userInfo.name = reader.GetString(1);
                            userInfo.email = reader.GetString(2);
                            userInfo.phone = reader.GetString(3);
                            userInfo.address = reader.GetString(4);


                            ListUsers.Add(userInfo);
                        }
                    }
                }
            }
            return View(ListUsers);
        }

        public IActionResult Edit(string Id)
        {
            
            string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                String sql = "SELECT * FROM userCaseSO WHERE id=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userInfo.id = "" + reader.GetInt32(0);
                            userInfo.name = reader.GetString(1);
                            userInfo.email = reader.GetString(2);
                            userInfo.phone = reader.GetString(3);
                            userInfo.address = reader.GetString(4);
                        }
                    }
                }
            }

            return View(userInfo);

        }

        [HttpPost]
        public IActionResult OnPost()
        {
            userInfo.id = Request.Form["id"];
            userInfo.name = Request.Form["name"];
            userInfo.email = Request.Form["email"];
            userInfo.phone = Request.Form["phone"];
            userInfo.address = Request.Form["address"];

            if (userInfo.id.Length == 0 || userInfo.name.Length == 0)
            {
                errorMessage = "All the field are required";
               
            }

            try
            {
                String connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE userCaseSO " +
                               "SET name=@name, email=@email, phone=@phone, address=@address " +
                               "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@name", userInfo.name);
                        command.Parameters.AddWithValue("@email", userInfo.email);
                        command.Parameters.AddWithValue("@phone", userInfo.phone);
                        command.Parameters.AddWithValue("@address", userInfo.address);
                        command.Parameters.AddWithValue("@id", userInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
               
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
              
            }
            return RedirectToAction("Index");
        }
    }
}
