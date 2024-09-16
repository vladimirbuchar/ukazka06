using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Validator;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Command
{
    public class CourseLessonUpdateService
        : BaseUpdateCommand<
            CourseLessonDbo,
            ICourseLessonRepository,
            CourseLessonUpdateDto,
            ICourseLessonUpdateConvertor,
            ICourseLessonUpdateValidator

        >,
            ICourseLessonUpdateService
    {
        public CourseLessonUpdateService(
            ICourseLessonRepository repository,
            ICourseLessonUpdateConvertor convertor,
            ICourseLessonUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
