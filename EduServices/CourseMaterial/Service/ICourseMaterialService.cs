using Core.Base.Filter;
using Core.Base.Service;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CourseMaterial.Service
{
    public interface ICourseMaterialService
        : IBaseService<
            CourseMaterialDbo,
            CourseMaterialCreateDto,
            CourseMaterialListDto,
            CourseMaterialDetailDto,
            CourseMaterialUpdateDto,
            CourseMaterialFileRepositoryDbo,
            FilterRequest
        >
    {
        Task<List<CourseMaterialFileListDto>> GetFiles(Guid courseMaterialId);
        Task<List<CourseMaterialFileListDto>> GetFilesStudent(Guid courseId);
    }
}
