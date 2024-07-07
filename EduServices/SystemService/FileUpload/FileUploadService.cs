using Core.Base.Service;

namespace Services.SystemService.FileUpload
{
    public class FileUploadService : BaseService // <IFileUploadRepository, FileRepositoryDbo>, IFileUploadService
    {
        /*private readonly IHttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPowerPointIntegration _powerPoint;
        private readonly string _fileRepositoryPath;

        public FileUploadService(IFileUploadRepository fileUploadRepository, IHttpClient httpClient, IHttpContextAccessor httpContextAccessor, IPowerPointIntegration powerPoint, IConfiguration configuration, IHostingEnvironment hostingEnvironment) : base(fileUploadRepository)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _powerPoint = powerPoint;
            string projectRootPath = hostingEnvironment.ContentRootPath;
            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection("FileRepository").Value);

        }

        public void FileUpload(Guid objectOwner, IList<IFormFile> files, string afterUploadEvent, string userAccessToken, bool delete)
        {
            _repository.CreateFileRepository(objectOwner);
            if (delete)
            {
                _repository.DeleteAllFiles(objectOwner);
            }
            foreach (IFormFile item in files)
            {
                Guid id = _repository.FileUpload(objectOwner, item);
                if (!afterUploadEvent.IsNullOrEmptyWithTrim())
                {
                    string url = string.Format("{0}://{1}{2}", _httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Value, afterUploadEvent);
                    Dictionary<string, string> data = new Dictionary<string, string>
                    {
                        { "FileId", id.ToString() },
                        { "ObjectOwner", objectOwner.ToString() }
                    };
                    _httpClient.SendPostAsync(url, userAccessToken, data);
                }
            }
        }
        public void FileDelete(Guid objectId)
        {
            
        }

        public GetFileDetail GetFileDetail(Guid fileId)
        {
            return _repository.GetFileDetail(fileId);
        }

        public List<PowerPointSlide> LoadPowerPointFile(string parent, string fileName)
        {
            return _powerPoint.ConvertToHtmlAsync(parent, fileName).Result;
        }

        public Guid SaveFilePngFile(string img, string directory)
        {
            Guid fileName = Guid.NewGuid();
            string filePath = string.Format("{0}{1}/{2}.png", _fileRepositoryPath, directory, fileName);
            byte[] data = Convert.FromBase64String(img.Replace("data:image/png;base64,", ""));
            using (var stream = new MemoryStream(data, 0, Length))
            {
                Image image = Image.FromStream(stream);
                image.Save(filePath);
            }
            return fileName;
        }*/
    }
}
