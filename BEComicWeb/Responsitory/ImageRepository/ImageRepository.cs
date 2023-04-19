using BEComicWeb.Interface.ImageInterface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BEComicWeb.Repository.ImageRepository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IHostingEnvironment _environment;
        public ImageRepository(IHostingEnvironment env)
        {
            _environment = env;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string storage)
        {
            var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", storage);
            var filepath = Path.Combine(folder_path, file.FileName);
            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            
            return filepath;
        }

        public async Task<Stream> GetImageAsync(string imageId)
        {
            throw new NotImplementedException();
        }
    }
}
