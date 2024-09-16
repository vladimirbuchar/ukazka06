using Core.Base.Command.Update;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Convertor;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Dto;
using CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Validator;
using Model.Edu.CourseTermDate;
using Repository.CourseTermDate;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableUpdate.Command
{
    public class CourseTermTimeTableUpdateService
        : BaseUpdateCommand<
            CourseTermDateDbo,
            ICourseTermDateRepository,
            CourseTermTimeTableUpdateDto,
            ICourseTermTimeTableUpdateConvertor,
            ICourseTermTimeTableUpdatevalidator

        >,
            ICourseTermTimeTableUpdateService
    {
        public CourseTermTimeTableUpdateService(
            ICourseTermDateRepository repository,
            ICourseTermTimeTableUpdateConvertor convertor,
            ICourseTermTimeTableUpdatevalidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
