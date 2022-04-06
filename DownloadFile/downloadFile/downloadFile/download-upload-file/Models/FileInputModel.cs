using Microsoft.AspNetCore.Http;

namespace download_upload_file.Models
{
    public class FileInputModel
    {
        public IFormFile FileToUpload { get; set; }
    }
}
