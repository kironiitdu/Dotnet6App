using Microsoft.AspNetCore.Mvc;

namespace DotNet6MVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult students()
        {

            return View();
        }
        //public List<Eventrole> AddandGetStudents(Students obj)
        //{

        //    List<Eventrole> studentslist = new List<Eventrole>();
        //    connection();
        //    SqlCommand com = new SqlCommand("prc_add", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@name", obj.Name);
        //    com.Parameters.AddWithValue("@email", obj.Email);

        //    SqlDataAdapter sqlDA = new SqlDataAdapter();
        //    DataTable dteventroles = new DataTable();

        //    con.Open();
        //    com.ExecuteNonQuery();
        //    sqlDA.Fill(dteventroles);
        //    con.Close();

        //    foreach (DataRow dr in dteventroles.Rows)
        //    {
        //        studentslist.Add(new Students
        //        {
        //            Name = dr["name"].ToString(),
        //            Email = dr["email"].ToString()
        //        });

        //    }
        //    return studentslist;
        //}
    }
}
