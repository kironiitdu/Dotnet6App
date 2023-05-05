//Binary Search Test 2022-05-12

using Newtonsoft.Json;
using System.Text;


//Rigion Call API from console
using (var client = new HttpClient())
{

    var requestMode = new HttpClientReqeustModel();

    requestMode.MyByteData = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf");
    requestMode.FilePath = @"D:\Md Farid Uddin Resume.pdf";
    requestMode.FileName = "MyFilename.pdf";

    //Create Multipart Request
    var formContent = new MultipartFormDataContent();

    formContent.Add(new StringContent(requestMode.FilePath), "FilePath");
    formContent.Add(new StreamContent(new MemoryStream(requestMode.MyByteData)), "MyByteData", requestMode.FileName);

    var response = await client.PostAsync("http://localhost:5094/UploadFiles", formContent);

    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"API Response Code: {response.StatusCode}");
        Console.WriteLine("Data posted successfully");
    }
}

public class HttpClientReqeustModel
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public byte[] MyByteData { get; set; }
}
public class WorkStationRandomValueDTO
{
    public int WorkStationId; //{ get; set; }
    public decimal Temperature; //{ get; set; }
    public decimal Pressure; //{ get; set; }
    public bool Status; //{ get; set; }

    
}

