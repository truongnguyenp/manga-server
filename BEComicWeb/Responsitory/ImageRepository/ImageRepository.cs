using BEComicWeb.Data;
using BEComicWeb.Interface.ImageInterface;
using BEComicWeb.Model.ImageModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BEComicWeb.Repository.ImageRepository
{
    public class ImageRepository : IImageRepository
    {
        public AppDbContext _dbContext = new();
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

            Image new_image = new();
            new_image.Name = file.FileName;
            new_image.Storage = storage;

            _dbContext.ImageDb.Add(new_image);
            _dbContext.SaveChanges();
            return filepath;
        }

        public async Task<Stream> GetImageAsync(string imageId)
        {
            throw new NotImplementedException();
        }
    }
}
