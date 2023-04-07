using BEComicWeb.Interface.Vultr;
using BEComicWeb.Model.Vultr;

namespace BEComicWeb.Responsitory.Vultr
{
    public class VultrRepository : IVultrRepository
    {
        private readonly VultrClient _vultrClient;

        public VultrRepository(VultrClient vultrClient)
        {
            _vultrClient = vultrClient;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string imageName)
        {
            return await _vultrClient.UploadImageAsync(file, imageName);
        }

        public async Task<Stream> GetImageAsync(string imageId)
        {
            return await _vultrClient.GetImageAsync(imageId);
        }
    }

}
