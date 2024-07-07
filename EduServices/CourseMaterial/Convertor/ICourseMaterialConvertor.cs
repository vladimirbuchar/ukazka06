using System.Collections.Generic;
using Core.Base.Convertor;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;

namespace Services.CourseMaterial.Convertor
{
    public interface ICourseMaterialConvertor : IBaseConvertor<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>
    {
        HashSet<CourseMaterialFileListDto> ConvertToWebModel(HashSet<CourseMaterialFileRepositoryDbo> getFiles);
    }
}
