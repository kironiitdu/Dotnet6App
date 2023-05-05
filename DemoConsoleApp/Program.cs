
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;


//ExceptionsAnalyzer().Wait();
//string[] formatStrings = { "C2", "E1", "F", "G3", "N", "#,##0.000", "0,000,000,000.0##" };
//CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US"); 
//Decimal[] values = { 1345.6538m, 1921651.16m };
//foreach (var value in values)
//{ 
//    foreach (var formatString in formatStrings) 
//    { 
//        string resultString = value.ToString(formatString, culture); 
//        Console.WriteLine("{0,-18} -->  {1}", formatString, resultString); 
//    } 
//    Console.WriteLine();
//}

//var httpClient = new HttpClient();
//httpClient.DefaultRequestHeaders.Clear();

//var message = new HttpRequestMessage(HttpMethod.Get, "https://url/api/someMethod");
//message.Headers.Add("Host", "somesite.site");
//message.Headers.Add("Test", "Test");
//message.Headers.Add("Authorization", "Bearer " + "token_New_TOken");
//var response = await httpClient.SendAsync(message);
//Console.WriteLine(message.ToString());
//using (var client = new HttpClient())
//{
//    client.DefaultRequestHeaders.Clear();

//    var message = new HttpRequestMessage(HttpMethod.Get, "https://url/api/someMethod");
//    message.Headers.Add("Host", "somesite.site");
//    message.Headers.Add("Test", "Test");
//    message.Headers.Add("Authorization", "Bearer " + "token_nndafdfad");
//    //var response = await httpClient.SendAsync(message);
//    Console.WriteLine(message.ToString());
//}
//var collections = "CP, RS, DS, CS";
//var search = "KS";

//var results = IsEnglandOrWales(collections,search);

//Console.WriteLine(results);

//var ddd  = Directory.GetDirectories("Downloads");
//if (ddd.Length > 0)
//{
//    foreach (string dir in ddd)
//    {
//        if (!Directory.EnumerateFileSystemEntries(dir, "*.gif").Any())
//        {
//            Directory.Delete(dir, true);
//        }
//    }
//}
var filePath = Directory.GetFiles(@"\\172.17.10.21\File30\Xiao Wang\Yohann Lu\Md Farid Uddin");
var ddd = Directory.GetFiles(@"C:\\Users\\uddin\\Downloads");
foreach (var items in filePath)
{
    if (items.Contains(".gif"))
    {
        Console.WriteLine("Deleting gif...");
        File.Delete(items);
    }
}


var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

int counter = 0;
while (await timer.WaitForNextTickAsync())
{
    counter++;
    if (counter > 5) break;
    MonitoringSystemService(counter).Wait();
}

static async Task MonitoringSystemService(int counter)
{
    DriveInfo[] drives = DriveInfo.GetDrives();
    foreach (DriveInfo drive in drives)
    {
        if (drive.IsReady)
        {
            //var client = new RestClient("http://your-api-url/api/drives");
            //var request = new RestRequest(Method.Post);
            //request.AddJsonBody(new
            //{
            //    SystemName = Environment.MachineName,
            //    UserName = Environment.UserName,
            //    DriveName = drive.Name,
            //    DriveSpace = drive.TotalFreeSpace,
            //    TotalDriveSpace = drive.TotalSize
            //});
            //IRestResponse response = client.Execute(request);

        }
        Console.WriteLine("Current counter: {0} Last Fired At: {1}, Drive Status: {2}", counter, DateTime.Now, drive.IsReady);
    }
}


static bool IsEnglandOrWales(string arrayClassificationCode, string search)
{

    return arrayClassificationCode.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Contains(search.Split(new[] { ',' }).FirstOrDefault());

}






static async Task ExceptionsAnalyzer()
{
    HttpClient _httpClient = new HttpClient();
    var obj = "Test data";
    string json = JsonSerializer.Serialize(obj);
    HttpResponseMessage response = await _httpClient.PostAsJsonAsync("http://localhost:5094/api/rest/CreateException", json);
    if (response.IsSuccessStatusCode)
    {

    }
}

static bool ContainsInt(string str, int value)
{
    return str.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.Parse(x.Trim()))
        .Contains(value);
}


static void AppendRequestHeader()
{
    var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Clear();

    var message = new HttpRequestMessage(HttpMethod.Get, "https://url/api/someMethod");
    message.Headers.Add("Host", "somesite.site");
    message.Headers.Add("Test", "Test");
    message.Headers.Add("Authorization", "Bearer " + "token_nndafdfad");
    //var response = await httpClient.SendAsync(message);
    Console.WriteLine(message.ToString());
    // return Json(message.ToString());
}


