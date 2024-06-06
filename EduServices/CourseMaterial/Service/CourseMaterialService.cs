using System;
using System.Collections.Generic;
using Core;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Core.DataTypes;
using EduRepository.CourseMaterialRepository;
using EduRepository.CourseRepository;
using EduServices.CourseMaterial.Convertor;
using EduServices.CourseMaterial.Dto;
using EduServices.CourseMaterial.Validator;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Course;
using Model.Tables.Edu.CourseMaterial;

namespace EduServices.CourseMaterial.Service
{
    public class CourseMaterialService(
        ICourseRepository courseRepository,
        ICourseMaterialRepository courseMaterialRepository,
        ICourseMaterialConvertor courseMaterialConvertor,
        ICourseMaterialValidator validator,
        IFileUploadRepository<CourseMaterialFileRepositoryDbo> repository,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseService<
            ICourseMaterialRepository,
            CourseMaterialDbo,
            ICourseMaterialConvertor,
            ICourseMaterialValidator,
            CourseMaterialCreateDto,
            CourseMaterialListDto,
            CourseMaterialDetailDto,
            CourseMaterialUpdateDto,
            CourseMaterialFileRepositoryDbo
        >(courseMaterialRepository, courseMaterialConvertor, validator, repository, culture),
            ICourseMaterialService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public HashSet<CourseMaterialFileListDto> GetFiles(Guid courseMaterialId)
        {
            return _convertor.ConvertToWebModel(_repository.GetFiles(courseMaterialId));
        }

        public HashSet<CourseMaterialFileListDto> GetFilesStudent(Guid courseId)
        {
            Guid? courseMaterialId = _courseRepository.GetEntity(courseId).CourseMaterialId;
            if (courseMaterialId != null)
            {
                return GetFiles(courseMaterialId.Value);
            }
            return null;
        }
    }
}
