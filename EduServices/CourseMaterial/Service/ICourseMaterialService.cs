using Core.Base.Service;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using System;
using System.Collections.Generic;

namespace Services.CourseMaterial.Service
{
    public interface ICourseMaterialService
        : IBaseService<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto, CourseMaterialFileRepositoryDbo>
    {
        HashSet<CourseMaterialFileListDto> GetFiles(Guid courseMaterialId);
        HashSet<CourseMaterialFileListDto> GetFilesStudent(Guid courseId);
    }
}
