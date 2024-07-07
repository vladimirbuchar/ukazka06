using System;
using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterialRepository;
using Repository.CourseRepository;
using Services.CourseMaterial.Convertor;
using Services.CourseMaterial.Dto;
using Services.CourseMaterial.Validator;

namespace Services.CourseMaterial.Service
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
            return _convertor.ConvertToWebModel(_repository.GetEntity(courseMaterialId).CourseMaterialFileRepositories.ToHashSet());
        }

        public HashSet<CourseMaterialFileListDto> GetFilesStudent(Guid courseId)
        {
            Guid? courseMaterialId = _courseRepository.GetEntity(courseId).CourseMaterialId;
            return courseMaterialId != null ? GetFiles(courseMaterialId.Value) : null;
        }
    }
}
