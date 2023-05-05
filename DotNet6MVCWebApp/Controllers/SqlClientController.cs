using DotNet6MVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DotNet6MVCWebApp.Controllers
{
    public class SqlClientController : Controller
    {

        private readonly IWebHostEnvironment _environment;

        string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
        public SqlClientController(IWebHostEnvironment environment)
        {
            _environment = environment;

        }




        


        public void BackupDatabase(string databaseName)
        {
            string filePath = BuildBackupPathWithFilename(databaseName);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = String.Format("BACKUP DATABASE [{0}] TO DISK='{1}'", databaseName, filePath);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public readonly string _backupFolderFullPath;
        private string BuildBackupPathWithFilename(string databaseName)
        {
            string filename = string.Format("{0}-{1}.bak", databaseName, DateTime.Now.ToString("yyyy-MM-dd"));
            var backupPath = "C:\\Program Files\\Microsoft SQL Server\\MSSQL14.MSSQLSERVER\\MSSQL\\Backup";

            var path = Path.Combine(backupPath, filename);

            return path;
        }

        public async Task<ActionResult> GetEmployeeIds(string searchText)
        {
            string query = "";


            query = "SELECT CAST(Id AS VARCHAR(50)) as EmployeeID,driverName AS EmployeeName FROM Driver WHERE  driverName LIKE '%" + searchText + "%'";


            try
            {
                ICollection<object> ApplicationsDataValues = new List<object>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (var command = con.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = CommandType.Text;


                        await command.Connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ApplicationsDataValues.Add(new
                                {
                                    EmployeeID = await reader.GetFieldValueAsync<string>(0)
                                });
                            }
                        }
                    }
                    await con.CloseAsync();
                    return StatusCode(200, ApplicationsDataValues);// Get all users  
                }


            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
            return Ok();
        }
        [HttpPost]
        public JsonResult GetEmployeeDetails()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SP_GetEmployeePrintInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                //Note I have tried both SqlDataAdapter and SqlDataReader
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.Fill(dt);

                con.Close();
                string serializeObject = JsonConvert.SerializeObject(dt);
                var dsriIntoClass = JsonConvert.DeserializeObject<List<PrinterClass>>(serializeObject);
                return Json(dsriIntoClass);
            }
        }
        [HttpGet]
        public JsonResult search()
        {
            //backupFilePath = backupFilePath + "\\" + databaseName + ".bak";
            //backupFilePath = @"" + backupFilePath;
            //var backupCommand = "BACKUP DATABASE @databaseName TO DISK = @backupFilePath";
            //using (var conn = new SqlConnection(connectionString))
            //using (var cmd = new SqlCommand(backupCommand, conn))
            //{
            //    conn.Open();
            //    cmd.Parameters.AddWithValue("@databaseName", databaseName);
            //    cmd.Parameters.AddWithValue("@backupFilePath", backupFilePath);
            //    cmd.ExecuteNonQuery();
            //}

            var databaseName = "WsAttendance";
            BackupDatabase(databaseName);


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


    public class PrinterClass
    {
        public int PrinterId { get; set; }    
        public string? PrinterName { get; set; }    
        public int TotalPrint { get; set; }    
    }
}
