//Binary Search Test 2022-05-12

using System.Net;
using System.Net.Http.Json;

int[] binaryTree = { 2, 3, 4, 10, 50, 70 };
//Calculating the lenth of tree
int treeLength = binaryTree.Length;
int left = 0;
int right = treeLength - 1;
int itemToSearch = 10;

using (var client = new HttpClient())
{
    var obj = "Test data";
    // Setting Base address.  
    client.BaseAddress = new Uri($"http://localhost:5094/");
    // Initialization.  
    HttpResponseMessage response = new HttpResponseMessage();
    // HTTP POST  
    //  response = await client.PostAsJsonAsync($"api/rest/issue/{issueKey}/attachments", fileInBase64).ConfigureAwait(false);
    response = await client.PostAsJsonAsync($"api/rest/CreateException", obj);
    // Verification  
    if (response.IsSuccessStatusCode)
    {
        // Reading Response.  
        var result = await response.Content.ReadAsStringAsync();
        //quejasImagenesResponse = JsonConvert.DeserializeObject<QuejasSugerenciaOpinionesImagenesResponse.Root>(result);
    }
}

//int result = binarySearch(binaryTree, left, right, itemToSearch);

//if (result == -1)
//    Console.WriteLine("Search item not present");
//else
//    Console.WriteLine("Search item  found at index of " + result);

verifyByOne();
Console.ReadLine();

 static void verifyByOne()
{
    string key = "uTuXFZWIpZ49nb6r3La5P";
    string email = "kironiitdu@outlook.com";
    string sURL = "https://app.emaillistvalidation.com/api/verifEmail?secret=" + key + "&email=" + email;
    WebRequest wrGETURL;
    wrGETURL = WebRequest.Create(sURL);

    WebProxy myProxy = new WebProxy("myproxy", 80);
    myProxy.BypassProxyOnLocal = true;

    wrGETURL.Proxy = WebProxy.GetDefaultProxy();

    Stream objStream;
    objStream = wrGETURL.GetResponse().GetResponseStream();

    StreamReader objReader = new StreamReader(objStream);

    string sLine = "";
    int i = 0;

    while (sLine != null)
    {
        i++;
        sLine = objReader.ReadLine();
        if (sLine != null)
            Console.WriteLine("{0}:{1}", i, sLine);
    }
    Console.ReadLine();
}

    //Binary tree search method

    static int binarySearch(int[] binaryTree, int left, int right, int itemToSearch)
{
    if (right >= left)
    {
        //Find the middle of tree
        int mid = left + (right - left) / 2;

        // If the element is present at the
        // middle itself
        if (binaryTree[mid] == itemToSearch)
            return mid;

        // If element is smaller than mid, then
        // it can only be present in left subarray
        if (binaryTree[mid] > itemToSearch)
            return binarySearch(binaryTree, left, mid - 1, itemToSearch);

        // Else the element can only be present
        // in right subarray
        return binarySearch(binaryTree, mid + 1, right, itemToSearch);
    }

    // We reach here when element is not present
    // in array
    return -1;
}