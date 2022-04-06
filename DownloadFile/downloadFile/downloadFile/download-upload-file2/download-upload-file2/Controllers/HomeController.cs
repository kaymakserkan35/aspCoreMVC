using download_upload_file2.Models;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace download_upload_file2.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }



        public IActionResult downloadFile()
        {
            string file = webHostEnvironment.WebRootPath + "\\test.txt";
            byte[] data = System.IO.File.ReadAllBytes(file);
            return File(data, "text/plain"); // could have specified the downloaded file name again here
        }

        public IActionResult downloadFileWithZip()
        {
            string file = webHostEnvironment.WebRootPath + "\\temp.zip"; // in production, would probably want to use a GUID as the file name so that it is unique
            System.IO.FileStream fs = System.IO.File.Create(file);
            using (ZipOutputStream zip = new ZipOutputStream(fs))
            {
                byte[] data;
                ZipEntry entry;
                entry = new ZipEntry("downloaded_file.txt");
                entry.DateTime = System.DateTime.Now;
                zip.PutNextEntry(entry);
                data = System.IO.File.ReadAllBytes(webHostEnvironment.WebRootPath + "\\test.txt");
                zip.Write(data, 0, data.Length);
                zip.Finish();
                zip.Close();
                fs.Dispose(); // must dispose of it
                fs = System.IO.File.OpenRead(file); // must re-open the zip file
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();
                System.IO.File.Delete(file);
                return File(data, "application/x-zip-compressed", "downloaded_file.zip"); // recommend specifying the download file name for zips
            }
        }
    }
}
