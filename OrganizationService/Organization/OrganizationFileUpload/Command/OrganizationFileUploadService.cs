using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.Organization;

namespace OrganizationService.Organization.OrganizationFileUpload.Command
{
    public class OrganizationFileUploadService : BaseServiceCommand<OrganizationFileRepositoryDbo>, IOrganizationFileUploadService
    {
        public OrganizationFileUploadService(
            IFileUploadRepository<OrganizationFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository) { }
    }
}
