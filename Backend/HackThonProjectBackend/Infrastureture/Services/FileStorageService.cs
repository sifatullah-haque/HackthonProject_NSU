using Microsoft.AspNetCore.Http.HttpResults;

namespace HackThonProjectBackend.Infrastureture.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }   

    public class FileStorageService: IFileStorageService
    {
        AppwriteStorageService appwriteStorageService = new AppwriteStorageService("" , "" , "" , "");
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }
            
            await Task.Delay(200); // Simulate upload delay
            return $"https://filestorage.example.com/{file.FileName}";
        }
    }
}
