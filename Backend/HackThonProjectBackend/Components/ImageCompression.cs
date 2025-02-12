using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace HackThonProjectBackend.Components
{
    public class ImageCompression
    {
        public async Task CompressImageAsync(Stream inputStream, Stream outputStream, int quality = 75)
        {
            
            using (var image = await Image.LoadAsync(inputStream))
            {
            
                var encoder = new JpegEncoder
                {
                    Quality = quality
                };

               
                await image.SaveAsJpegAsync(outputStream, encoder);
            }
        }
    }
}
