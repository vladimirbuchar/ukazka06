using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Validator;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLesson;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Command
{
    public class CourseLessonItemCreateService
        : BaseCreateCommand<
            CourseLessonItemDbo,
            ICourseLessonItemRepository,
            CourseLessonItemCreateDto,
            ICourseLessonItemCreateConvertor,
            ICourseLessonItemCreateValidator
        >,
            ICourseLessonItemCreateService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;

        public CourseLessonItemCreateService(
            ICourseLessonRepository courseLessonRepository,
            ICourseLessonItemRepository repository,
            ICourseLessonItemCreateConvertor convertor,
            ICourseLessonItemCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture)
        {
            _courseLessonRepository = courseLessonRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseLessonRepository.GetOrganizationId(objectId);
        }
    }
}
