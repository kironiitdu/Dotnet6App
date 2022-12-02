using ClosedXML.Excel;
using Dotnet6App.Data;
using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Xml.Linq;

namespace Dotnet6App.Controllers
{
    [ApiController]
    [Route("api/VehicleFilter")]
    public class VehicleFilterController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public VehicleFilterController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        
        [HttpGet]
        public  IActionResult GetAllFilter(int id)
        {
            string query = @"select ID,CustomerID,CustomerName,CustomerEmail from Order where ID = @ID ";
            DataTable table = new DataTable();
            string sqlDataSource = "Server=WX-6899;Database=TestIdentityDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ID", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        //[Route("DeleteFromTable")]
        //[HttpGet]
        //public async Task<IActionResult> DeleteFromTable()
        //{
        //    try
        //    {
        //        // var sqlCommand = $"SELECT Id, FirstName,LastName,Email FROM [User]";
        //        var tableName = "[VehicleFilter]";
        //        var id = 1;
        //        await _context.Database.ExecuteSqlRawAsync($"DELETE FROM {tableName} WHERE VehicleId =  @p0", id);
        //        _context.SaveChanges();
        //        return Ok("");
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
        //[Route("GetUsersFromRawSQL")]
        //[HttpGet]
        //public async Task<IActionResult> GetUsersFromRawSQL()
        //{
        //    try
        //    {
        //        // var sqlCommand = $"SELECT Id, FirstName,LastName,Email FROM [User]";

        //        var sqlCommand = $"SELECT * FROM [User]";
        //        var executeSQL = await _context.User.FromSqlRaw(sqlCommand).ToListAsync();
        //        //var p = _context.GetType.GetProperty("User").getValue(_context, null);
        //        var tableName = "User";
        //        string Raw = string.Format("SELECT * FROM [{0}];", tableName);
        //        var table = _context.Database.ExecuteSqlRaw(Raw);

        //        using (var connection = _context.Database.GetDbConnection())
        //        {
        //            connection.Open();
        //            List<User> _listUsers = new List<User>();
        //            var command = connection.CreateCommand();
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = string.Format("SELECT * FROM [{0}];", tableName);
        //            SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                var user = new User(); // You have to bind dynamic property here based on your table entities
        //                user.FirstName = reader["FirstName"].ToString(); // Remember Type Casting is required here it has to be according to database column data type
        //                user.LastName = reader["LastName"].ToString();
        //                _listUsers.Add(user);

        //            }

        //            reader.Close();
        //            command.Dispose();
        //            connection.Close();

        //        }


        //        return Ok(executeSQL);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
        public class Names
        {
            public List<string> names { get; set; }

        }

        string apiSecret = "uTuXFZWIpZ49nb6r3La5P";
        //[Route("GetDetails")]
        //[HttpPost]
        //public async Task<IActionResult> GetDetails([FromBody] Names names)
        //{
        //    return Ok(names);
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAllFilter()
        //{

        //    string VehicleName = "Hatchback";
        //    var sqlCommand = $"EXEC GetVehicleByTile {VehicleName}";
        //    var vehicleFilterValues = await _context.VehicleFilter.FromSqlRaw(sqlCommand).ToListAsync();
        //    return Ok(vehicleFilterValues);
        //}

        public class UserViewModel
        {

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public List<IFormFile> profilePicture { get; set; }
        }

        public async Task<string> File(IFormFile file)
        {
            string wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, "Images/", file.FileName);
            if (file.FileName.Length > 0)
            {
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            return "uploaded";
        }

        [Route("CreateUserProfilePic")]
        [HttpPost]
        public async Task<IActionResult> CreateUserProfilePic([FromForm] UserViewModel model)
        {

            if (model == null)
            {
                return Content("Invalid Submission!");
            }
            //Insert in User Model
            var userModel = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,

            };
            _context.Add(userModel);
            await _context.SaveChangesAsync();
            var lastUserId = userModel.Id;

            foreach (var item in model.profilePicture)
            {

                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");
                }
                var path = Path.Combine(_environment.WebRootPath, "Images/", item.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }


                //Insert In User Profile table
                var userProfileModel = new UserProfilePicture
                {
                    UserId = lastUserId.ToString(),
                    ImageName = item.FileName,
                    ImagePath = path

                };
                _context.Add(userProfileModel);
                await _context.SaveChangesAsync();
            }

            var listData = _context.userProfilePictures.Where(uid => uid.UserId == lastUserId.ToString()).ToList();


            return Ok(listData);

        }


        [Route("ValidateEmail")]
        [HttpGet]
        public async Task<IActionResult> ValidateEmail(string emailId)
        {
            var handler = new HttpClientHandler();
            var data = "";

            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();

            var responseFromApi = await client.GetAsync("https://app.emaillistvalidation.com/api/verifEmail?secret=" + apiSecret + "&email=" + emailId + "");
            if (responseFromApi.IsSuccessStatusCode)
            {
                data = await responseFromApi.Content.ReadAsStringAsync();
               
            }

            return Ok(data);
        }
        [Route("Excel")]
        [HttpGet]
        public IActionResult Excel()
        {

            //Getting Member List
            var membersList = _context.User.ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("MemberList");
                var currentRow = 1;

                //Excel Header
                worksheet.Cell(currentRow, 1).Value = "ID";
                worksheet.Cell(currentRow, 2).Value = "FirstName";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "Email";

                //Excel Body
                foreach (var member in membersList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = member.Id;
                    worksheet.Cell(currentRow, 2).Value = member.FirstName;
                    worksheet.Cell(currentRow, 3).Value = member.LastName;
                    worksheet.Cell(currentRow, 4).Value = member.Email;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Members.xlsx");
                }
            }
        }

    }
}

