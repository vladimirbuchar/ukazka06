using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Validator;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Command
{
    public class CourseLessonCreateService
        : BaseCreateCommand<
            CourseLessonDbo,
            ICourseLessonRepository,
            CourseLessonCreateDto,
            ICourseLessonCreateConvertor,
            ICourseLessonCreateValidator
        >,
            ICourseLessonCreateService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;

        public CourseLessonCreateService(
            ICourseMaterialRepository courseMaterialRepository,
            ICourseLessonRepository repository,
            ICourseLessonCreateConvertor convertor,
            ICourseLessonCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseMaterialRepository.GetOrganizationId(objectId);
        }
    }
}
