using DotNet6MVCWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;

namespace DotNet6MVCWebApp.Controllers
{
    public class DownloadAllController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public static List<FileDetails> fileList = new List<FileDetails>()
        {
            new FileDetails() { FileId =101, FileName ="A", ImageName = "Microsoft_png.png",},
            new FileDetails() { FileId =102, FileName ="B", ImageName = "du.png"  },
            new FileDetails() { FileId =103, FileName ="C", ImageName = "ChinaFlag.png" },

        };
        public DownloadAllController(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        public IActionResult Index()
        {

            return View(fileList);
        }


        public async Task<IActionResult> DownLoadAll()
        {

            var folderPath = Path.GetFullPath("./wwwroot/ImageName/Cover/");

            // Make sure the folder exists
            if (!Directory.Exists(folderPath))
                return NotFound("Folder has not found.");

            // Getting list of files in the folder
            var files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
                return NotFound("No files has founded to download.");

            // Creating a temporary memory stream to hold the zip archive
            using (var memoryStream = new MemoryStream())
            {
                // Create a new zip archive
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);

                        // Create a new entry in the zip archive for each file
                        var entry = zipArchive.CreateEntry(fileInfo.Name);

                        // Write the file contents into the entry
                        using (var entryStream = entry.Open())
                        using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                //Finally return the zip file as a byte array into zip folder
                var zipFileName = $"DownloadedFiles-{DateTime.Now.ToString("yyyy_MM_dd")}.zip";
                return File(memoryStream.ToArray(), "application/zip", zipFileName);
                
            }
        }


    }

    public class FileDetails
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageContent { get; set; }

    }
}
