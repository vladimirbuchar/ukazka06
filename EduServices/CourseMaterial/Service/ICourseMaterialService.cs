using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.CourseMaterial.Dto;
using Model.Edu.CourseMaterial;

namespace EduServices.CourseMaterial.Service
{
    public interface ICourseMaterialService
        : IBaseService<CourseMaterialDbo, CourseMaterialCreateDto, CourseMaterialListDto, CourseMaterialDetailDto, CourseMaterialUpdateDto, CourseMaterialFileRepositoryDbo>
    {
        HashSet<CourseMaterialFileListDto> GetFiles(Guid courseMaterialId);
        HashSet<CourseMaterialFileListDto> GetFilesStudent(Guid courseId);
    }
}
