using Core.Base.Command.Detail;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Conveertor;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Dto;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonDetail.Command
{
    public class CourseLessonDetailService
        : BaseDetailCommand<CourseLessonDbo, ICourseLessonRepository, CourseLessonDetailDto, ICourseLessonDetailConvertor>,
            ICourseLessonDetailService
    {
        public CourseLessonDetailService(ICourseLessonRepository repository, ICourseLessonDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
