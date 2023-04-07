namespace BEComicWeb.Interface.Vultr
{
    public interface IVultrRepository
    {
        Task<string> UploadImageAsync(IFormFile file, string imageName);
        Task<Stream> GetImageAsync(string imageId);
    }
}
