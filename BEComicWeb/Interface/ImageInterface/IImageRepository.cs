namespace BEComicWeb.Interface.ImageInterface
{
    public interface IImageRepository
    {
        public Task<string> UploadImageAsync(IFormFile file, string story_id, string chapter_id);
        public Task<Stream> GetImageAsync(string imageId);
    }
}
