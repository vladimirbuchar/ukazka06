using System;

namespace Integration.ImagePng
{
    public interface IImagePngIntegration
    {
        Guid SaveFilePngFile(string img, string directory);
    }
}