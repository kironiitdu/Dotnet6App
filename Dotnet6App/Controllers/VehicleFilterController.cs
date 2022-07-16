using Dotnet6App.Data;
using Dotnet6App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;

namespace Dotnet6App.Controllers
{
    [ApiController]
    [Route("api/VehicleFilter")]
    public class VehicleFilterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VehicleFilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("DeleteFromTable")]
        [HttpGet]
        public async Task<IActionResult> DeleteFromTable()
        {
            try
            {
                // var sqlCommand = $"SELECT Id, FirstName,LastName,Email FROM [User]";
                var tableName = "[VehicleFilter]";
                var id = 1;
                await _context.Database.ExecuteSqlRawAsync($"DELETE FROM {tableName} WHERE VehicleId =  @p0", id);
                _context.SaveChanges();
                return Ok("");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [Route("GetUsersFromRawSQL")]
        [HttpGet]
        public async Task<IActionResult> GetUsersFromRawSQL()
        {
            try
            {
                // var sqlCommand = $"SELECT Id, FirstName,LastName,Email FROM [User]";

                var sqlCommand = $"SELECT * FROM [User]";
                var executeSQL = await _context.User.FromSqlRaw(sqlCommand).ToListAsync();
                //var p = _context.GetType.GetProperty("User").getValue(_context, null);
                var tableName = "User";
                string Raw = string.Format("SELECT * FROM [{0}];", tableName);
                var table = _context.Database.ExecuteSqlRaw(Raw);

                using (var connection = _context.Database.GetDbConnection())
                {
                    connection.Open();
                    List<User> _listUsers = new List<User>();
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = string.Format("SELECT * FROM [{0}];", tableName);
                    SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new User(); // You have to bind dynamic property here based on your table entities
                        user.FirstName = reader["FirstName"].ToString(); // Remember Type Casting is required here it has to be according to database column data type
                        user.LastName = reader["LastName"].ToString();
                        _listUsers.Add(user);

                    }
                   
                    reader.Close();
                    command.Dispose();
                    connection.Close();

                }


                return Ok(executeSQL);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilter()
        {
            
            string VehicleName = "Hatchback";
            var sqlCommand = $"EXEC GetVehicleByTile {VehicleName}";
            var vehicleFilterValues = await _context.VehicleFilter.FromSqlRaw(sqlCommand).ToListAsync();
            return Ok(vehicleFilterValues);
        }
    }
}
