using Core.Base.Command.Update;
using CourseStudyService.CourseStudy.ResetCourse.Convertor;
using CourseStudyService.CourseStudy.ResetCourse.Dto;
using CourseStudyService.CourseStudy.ResetCourse.Validator;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.CourseStudy.ResetCourse.Command
{
    public class ResetCourseCommand : BaseUpdateCommand<CourseStudentDbo, ICourseStudentRepository, ResetCourseDto, IResetCourseConvertor, IResetCourseValidator>, IResetCourseCommand
    {
        public ResetCourseCommand(ICourseStudentRepository repository, IResetCourseConvertor convertor, IResetCourseValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
