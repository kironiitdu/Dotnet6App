
using System.Net.Http.Json;
using System.Text.Json;


ExceptionsAnalyzer().Wait();

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