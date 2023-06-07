using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace RazorPageDemoApp.Pages
{
    public class ReadFromDataTableModel : PageModel
    {
        string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
        public List<TopscoorderTotaal>? TopscoorderTotaals { get; set; }
        public void OnGet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var query = "SELECT Topscoorder ,Doelpunten ,Vlag ,Team FROM TopscoorderTotaal";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                con.Close();
                string serializeObject = JsonConvert.SerializeObject(dt);
                var dataTableObjectInPOCO = JsonConvert.DeserializeObject<List<TopscoorderTotaal>>(serializeObject);
                TopscoorderTotaals = dataTableObjectInPOCO;
            }
        }
    }

    public class TopscoorderTotaal
    {
        public string? Topscoorder { get; set; }
        public int Doelpunten { get; set; }
        public string? Vlag { get; set; }
        public string? Team { get; set; }
    }
   
}
