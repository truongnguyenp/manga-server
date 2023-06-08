using BEComicWeb.Data;
using BEComicWeb.Interface.ImageInterface;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<string> UploadImageAsync([FromForm] IFormFile file, string? story_id, string? chapter_id = null)
        {
            var folder_path = Path.Combine(_environment.ContentRootPath, "Data", "ImageStorage", story_id);
            if (chapter_id != null)
                folder_path = Path.Combine(folder_path, chapter_id);
            string file_name;
            if (file.FileName == null)
                file_name = Guid.NewGuid().ToString();
            else
                file_name = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(folder_path, file_name);
            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }
            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            string imageUrl = $"http://localhost:5000/Data/ImageStorage/{story_id}/{(chapter_id != null ? chapter_id + "/" : "")}{file_name}";
            return imageUrl;
        }

        public async Task<Stream> GetImageAsync(string imageId)
        {
            throw new NotImplementedException();
        }
    }
}
