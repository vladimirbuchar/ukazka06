using Core.Base.Command.List;
using Core.Base.Filter;
using CourseMaterialService.CourseMaterial.GetFiles.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.GetFiles.Command
{
    public interface IGetFilesService : IBaseListCommand<CourseMaterialFileRepositoryDbo, CourseMaterialFileListDto, RequestFilter> { }
}
