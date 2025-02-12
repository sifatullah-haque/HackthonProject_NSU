using System.IO;
using System.Threading.Tasks;
using Appwrite;
using Appwrite.Models;
using Appwrite.Services; // Adjust based on the SDK version

namespace HackThonProjectBackend.Infrastureture.Services
{
    public class AppwriteStorageService
    {
        private readonly Client _client;
        private readonly Storage _storage;
        private readonly string _bucketId;
 
        public AppwriteStorageService(string endpoint, string projectId, string apiKey, string bucketId)
        {
            _client = new Client();
            _client
                .SetEndpoint(endpoint)
                .SetProject(projectId)
                .SetKey(apiKey);

            _storage = new Storage(_client);
            _bucketId = "67ac46aa003a39a348e8";
        }

        
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {

            var result = await _storage.CreateFile(
                bucketId: _bucketId,
                file: new InputFile()
                {
                    Data = fileStream ,
                    Filename = fileName ,
                    Path = fileName ,   
                },

                fileId: fileName

            );

           
            string fileUrl = $"{_client.Endpoint}/storage/buckets/{_bucketId}/files/{result.Id}/view?project=";
            return fileUrl;
        }
    }
}
