using Core.Base.Validator;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using Model.Edu.CourseTermDate;
using Repository.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Validator
{
    public class CourseTermTimeTableUpdatevalidator
        : BaseUpdateValidator<CourseTermDateDbo, ICourseTermDateRepository, CourseTermTimeTableUpdateDto>,
            ICourseTermTimeTableUpdatevalidator
    {
        public CourseTermTimeTableUpdatevalidator(ICourseTermDateRepository repository)
            : base(repository) { }
    }
}
