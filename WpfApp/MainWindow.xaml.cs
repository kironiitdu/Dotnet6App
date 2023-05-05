using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Document
    {
        public string FileName { get; set; }
        public byte[] Buffer { get; set; }

    }


    public class Request
    {
        public string Uploader { get; set; }
        public List<Document> Documents { get; set; }
    }
    public class Users
    {

        [Key]
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? LoginId { get; set; }
        public string? Password { get; set; }
    }
    public class WpfInMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "WsAttendance");
        }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>().ToTable("Users");


        }
    }

    public partial class MainWindow : Window
    {
        private WpfInMemoryDbContext? wpfInMemoryDbContext;
        public MainWindow()
        {
            InitializeComponent();

        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

           


            var obj = new Request()
            {
                Uploader = "Md Farid Udddin Kiron",
                Documents = new List<Document>
                    {
                        new Document()
                        {
                            FileName ="I Love Coding.pdf",
                            Buffer = System.IO.File.ReadAllBytes(@"D:\Md Farid Uddin Resume.pdf")
                        }
                    }
            };


            var httpClient = new HttpClient
            {
                BaseAddress = new("https://webapidebug.azurewebsites.net")
            };


            var formContent = new MultipartFormDataContent();
            //formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data;boundary=");
            formContent.Add(new StringContent(obj.Uploader), "Uploader");

            formContent.Add(new StringContent(obj.Documents[0].FileName), "Documents[0].FileName");
            formContent.Add(new StreamContent(new MemoryStream(obj.Documents[0].Buffer)), "Documents[0].Buffer", obj.Documents[0].FileName);



            var response = await httpClient.PostAsync("/api/upload", formContent);

            if (response.IsSuccessStatusCode)
            {
                var responseFromAzureIIS = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
