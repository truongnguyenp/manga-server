﻿using Newtonsoft.Json;

namespace BEComicWeb.Model.Vultr
{
    public class VultrClient
    {
        private readonly HttpClient _httpClient;
        private readonly VultrOptions _options;

        public VultrClient(HttpClient httpClient, VultrOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string imageName)
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(_options.ApiKey), "api_key");
            form.Add(new StringContent(_options.StorageZone), "storage_zone");
            form.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            form.Add(new StringContent(imageName), "description");

            var repos = await _httpClient.PostAsync($"{_options.BaseUrl}/v1/object/store", form);

            repos.EnsureSuccessStatusCode();

            var json = await repos.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VultrUploadResult>(json);

            return result.data.id;
        }

        public async Task<Stream> GetImageAsync(string imageId)
        {
            var Repository = await _httpClient.GetAsync($"{_options.BaseUrl}/v1/object/get/{imageId}");

            Repository.EnsureSuccessStatusCode();

            return await Repository.Content.ReadAsStreamAsync();
        }
    }

    public class VultrUploadResult
    {
        public VultrUploadData data { get; set; }
    }

    public class VultrUploadData
    {
        public string id { get; set; }
        public string description { get; set; }
    }

}
