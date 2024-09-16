using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.IO;

namespace Integration.ImagePng
{
    public class ImagePngIntegration : IImagePngIntegration
    {
        private readonly string _fileRepositoryPath;

        [Obsolete]
        public ImagePngIntegration(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection("FileRepository").Value);

        }
        public Guid SaveFilePngFile(string img, string directory)
        {
            Guid fileName = Guid.NewGuid();
            string filePath = Path.Combine(_fileRepositoryPath, directory, fileName.ToString() + ".png");
            byte[] data = Convert.FromBase64String(img.Replace("data:image/png;base64,", ""));

            using (MemoryStream stream = new(data))
            using (Image<Rgba32> image = Image.Load<Rgba32>(stream))
            {
                image.Save(filePath, new PngEncoder());
            }

            return fileName;
        }


    }
}
