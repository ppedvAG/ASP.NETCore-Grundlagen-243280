using BusinessLogic.Contracts;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace BusinessLogic.Services
{
    public class FileServiceOptions
    {
        public string BaseUrl { get; set; }
    }

    public class RemoteFileService : IFileService
    {
        private readonly IOptions<FileServiceOptions> _options;
        private readonly HttpClient _httpClient;

        public RemoteFileService(IOptions<FileServiceOptions> options, HttpClient httpClient)
        {
            _options = options;
            _httpClient = httpClient;
            if (!string.IsNullOrWhiteSpace(options.Value.BaseUrl))
            {
                _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            } 
            else
            {
                //throw new ArgumentException("Keine valide BaseUrl konfiguriert!");

                // TODO fix later
                options.Value.BaseUrl = "http://localhost:5101";
            }
        }

        public async Task<string> UploadFile(string fileName, Stream stream)
        {
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);

            var formContent = new MultipartFormDataContent
            {
                { content, "file", fileName }
            };

            var response = await _httpClient.PostAsync("upload", formContent);
            if (response.IsSuccessStatusCode)
            {
                var resourceUrl = await response.Content.ReadAsStringAsync();
                return resourceUrl;
            }
            else
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }
        }
    }
}
