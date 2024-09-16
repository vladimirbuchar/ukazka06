using Core.Base.Command.List;
using Core.Base.Filter;
using Core.Base.Repository.FileRepository;
using CourseMaterialService.CourseMaterial.GetFiles.Convertor;
using CourseMaterialService.CourseMaterial.GetFiles.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.GetFiles.Command
{
    public class GetFilesService
        : BaseListCommand<
            CourseMaterialFileRepositoryDbo,
            IFileUploadRepository<CourseMaterialFileRepositoryDbo>,
            CourseMaterialFileListDto,
            IGetFilesConvertor,
            RequestFilter
        >,
            IGetFilesService
    {
        public GetFilesService(IFileUploadRepository<CourseMaterialFileRepositoryDbo> repository, IGetFilesConvertor convertor)
            : base(repository, convertor) { }
    }
}
