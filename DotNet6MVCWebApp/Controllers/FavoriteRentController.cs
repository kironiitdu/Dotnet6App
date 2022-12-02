using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Mvc;
using MigraDoc.Rendering;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace DotNet6MVCWebApp.Controllers
{
    public class FavoriteRentController : Controller
    {
        public IActionResult Index()
        {
            var rentModelList = new List<RentModel>()
            {
                new RentModel() { id=101,tittle="Test Title-1", price = "5000",descrip ="Description-1", areaUnit ="Area Unit-1",area = 1, province = "Alberta-1", city ="Edmonton-1",stadress ="Adress-1-1",furnished ="Yes-1" },
                new RentModel() { id=102,tittle="Test Title-2", price = "6000",descrip ="Description-2", areaUnit ="Area Unit-2",area = 1, province = "Alberta-2", city ="Edmonton-2",stadress ="Adress-1-2",furnished ="Yes-2" },
                new RentModel() { id=103,tittle="Test Title-3", price = "7000",descrip ="Description-3", areaUnit ="Area Unit-3",area = 1, province = "Alberta-3", city ="Edmonton-3",stadress ="Adress-1-3",furnished ="Yes-3" },
                new RentModel() { id=104,tittle="Test Title-4", price = "8000",descrip ="Description-4", areaUnit ="Area Unit-4",area = 1, province = "Alberta-4", city ="Edmonton-4",stadress ="Adress-1-4",furnished ="Yes-4" },
                new RentModel() { id=105,tittle="Test Title-5", price = "9000",descrip ="Description-5", areaUnit ="Area Unit-5",area = 1, province = "Alberta-5", city ="Edmonton-5",stadress ="Adress-1-5",furnished ="Yes-5" },
               



            };
            return View(rentModelList);
            
        }

        public List<RentModel> GetDataHouse()
        {
            string connectionString = "Data Source=WX-6899;Initial Catalog=WsAttendance;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<RentModel> dataList = new List<RentModel>();
                SqlCommand command = new SqlCommand("SELECT *,img.pic1 FROM rent FULL OUTER JOIN img ON rent.id=img.id  WHERE p_type = 'House'", con);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM img", con);
                SqlDataAdapter sqlda = new SqlDataAdapter(command);
                //SqlDataAdapter sqlad = new SqlDataAdapter(cmd);
                DataTable dtdata = new DataTable();
                con.Open();
                sqlda.Fill(dtdata);
                /*sqlad.Fill(dtdata)*/
                ;
                con.Close();
                foreach (DataRow dr in dtdata.Rows)
                {
                    dataList.Add(new RentModel
                    {


                        id = (dr["ID"] as int?) ?? 0,
                        tittle = dr["tittle"] as string,
                        descrip = dr["descrip"] as string,
                        area = (dr["area"] as int?) ?? 0,
                        areaUnit = dr["areaUnit"] as string,
                        bathroom = dr["bathroom"] as string,
                        bedroom = dr["bedroom"] as string,
                        province = dr["province"] as string,
                        city = dr["city"] as string,
                        stadress = dr["stadress"] as string,
                        furnished = dr["furnished"] as string,
                        p_type = dr["p_type"] as string,
                        price = dr["price"] as string,
                        pic1 = dr["pic1"] as string
                    });
                }
                return dataList;
            }
            
             
        }
        public IActionResult Rent(int PageNumber = 1)
        {

            var data = GetDataHouse();
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 5.0);
            data = data.Skip((PageNumber - 1) * 5).Take(5).ToList();
            return View(data);
        }

    }
    public class RentModel
    {
        public int id { get; set; }
        public string tittle { get; set; }
        public string price { get; set; }
        public string descrip { get; set; }

        public string areaUnit { get; set; }
        public int area { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string stadress { get; set; }

        public string? bathroom { get; set; }
        public string? furnished { get; set; }
        public string? p_type { get; set; }
        public string? bedroom { get; set; }
        public int? p_id { get; set; }

        public string? pic1 { get; set; }


        public IList<IFormFile>? photos { get; set; }

        public string? pic2 { get; set; }




        public string? pic3 { get; set; }



        public string? pic4 { get; set; }



        public string? pic5 { get; set; }



        public string? pic6 { get; set; }



        public string? pic7 { get; set; }


        public int r_id
        {
            get; set;

        }
    }
}
