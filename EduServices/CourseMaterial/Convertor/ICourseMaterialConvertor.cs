using Core.Base.Convertor;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using System.Collections.Generic;

namespace Services.CourseMaterial.Convertor
{
    public interface ICourseMaterialConvertor : IBaseConvertor<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>
    {
        HashSet<CourseMaterialFileListDto> ConvertToWebModel(HashSet<CourseMaterialFileRepositoryDbo> getFiles);
    }
}
