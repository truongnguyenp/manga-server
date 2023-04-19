namespace BEComicWeb.Interface.ImageInterface
{
    public interface IImageRepository
    {
        public Task<string> UploadImageAsync(IFormFile file, string storage);
        public Task<Stream> GetImageAsync(string imageId);
    }
}
