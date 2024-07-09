using System;
using System.Collections.Generic;
using Core.Base.Request;
using Core.Base.Service;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;

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
        List<CourseMaterialFileListDto> GetFiles(Guid courseMaterialId);
        List<CourseMaterialFileListDto> GetFilesStudent(Guid courseId);
    }
}
