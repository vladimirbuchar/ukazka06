using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.CourseMaterial.Dto;
using Model.Edu.CourseMaterial;

namespace EduServices.CourseMaterial.Convertor
{
    public interface ICourseMaterialConvertor : IBaseConvertor<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>
    {
        HashSet<CourseMaterialFileListDto> ConvertToWebModel(HashSet<CourseMaterialFileRepositoryDbo> getFiles);
    }
}
