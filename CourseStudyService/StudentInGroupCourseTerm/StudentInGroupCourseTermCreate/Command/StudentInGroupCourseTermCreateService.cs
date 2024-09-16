using Core.Base.Command.Create;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Convertor;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Validator;
using Model.Link;
using Repository.StudentInGroupCourseTerm;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Command
{
    public class StudentInGroupCourseTermCreateService(
        IStudentInGroupCourseTermRepository repository,
        IStudentInGroupCourseTermCreateConvertor convertor,
        IStudentInGroupCourseTermCreateValidator validator
        )
                : BaseCreateCommand<
            StudentInGroupCourseTermDbo,
            IStudentInGroupCourseTermRepository,
            StudentInGroupCourseTermCreateDto,
            IStudentInGroupCourseTermCreateConvertor,
            IStudentInGroupCourseTermCreateValidator
        >(repository, convertor, validator),
            IStudentInGroupCourseTermCreateService
    {
    }
}
