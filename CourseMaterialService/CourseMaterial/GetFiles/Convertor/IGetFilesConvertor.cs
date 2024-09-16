using Core.Base.Convertor;
using CourseMaterialService.CourseMaterial.GetFiles.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.GetFiles.Convertor
{
    public interface IGetFilesConvertor : IBaseListConvertor<CourseMaterialFileRepositoryDbo, CourseMaterialFileListDto> { }
}
