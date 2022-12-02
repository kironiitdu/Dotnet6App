using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DotNet6MVCWebApp.Controllers
{
    public class CalculateAgeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CalulateAgeFromDob(DateTime dateOfBirth)
        {
            var age = CalculateAge(dateOfBirth);
            return Json(age);
        }
        public object CalculateAge(DateTime dateOfBirth)
        {
            //DateTime birth = new DateTime(1988, 08, 02);
            DateTime birth = dateOfBirth;
            DateTime today = DateTime.Now;
            TimeSpan span = today - birth;
            DateTime age = DateTime.MinValue + span;

            // Make adjustment due to MinValue equalling 1/1/1int years = age.Year - 1;
            int months = age.Month - 1;
            int days = age.Day - 1;

            // Print out not only how many years old they are but give months and days as well
            var ageInYMD = string.Format("{0} years, {1} months, {2} days", age.Year, months, days);
            var ageInYM = string.Format("{0} years, {1} months", age.Year, months);
            var ageInY = string.Format("{0} years", age.Year);

            return ageInYM;
        }

       
        public UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public IActionResult SubmitFormOldFashion()
        {
            return View();
        }
        public List<UserInfo> ListUsers = new List<UserInfo>();

        public IActionResult UserListView()
        {
            OnGetList();
            return View(ListUsers);
        }
        public IActionResult LoadEditView()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM userCaseSO WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
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

              


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return View(userInfo);
        }
        public void OnGetList()
        {
            try
            {
                String connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());
            }
        }


    public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM userCaseSO WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
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
             
                    Response.Redirect("/CalculateAge/LoadEditView");


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        [HttpPost]
        public void OnPost()
        {
            userInfo.id = Request.Form["id"];
           // userInfo.id = Convert.ToInt32(Request.Form["id"]);
            userInfo.name = Request.Form["name"];
            userInfo.email = Request.Form["email"];
            userInfo.phone = Request.Form["phone"];
            userInfo.address = Request.Form["address"];

            if (userInfo.id.Length == 0 || userInfo.name.Length == 0 )
            {
                errorMessage = "All the field are required";
                return;
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
                OnGet();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/CalculateAge/UserListView");
        }
    }
}
