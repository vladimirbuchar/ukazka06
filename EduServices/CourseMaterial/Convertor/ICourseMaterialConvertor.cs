using Core.Base.Convertor;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CourseMaterial.Convertor
{
    public interface ICourseMaterialConvertor
        : IBaseConvertor<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto>
    {
        Task<List<CourseMaterialFileListDto>> ConvertToWebModel(List<CourseMaterialFileRepositoryDbo> getFiles);
    }
}
