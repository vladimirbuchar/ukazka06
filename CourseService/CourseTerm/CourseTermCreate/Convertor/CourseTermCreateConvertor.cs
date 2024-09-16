using CourseService.CourseTerm.CourseTermCreate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermCreate.Convertor
{
    public class CourseTermCreateConvertor : ICourseTermCreateConvertor
    {
        public Task<CourseTermDbo> ConvertToBussinessEntity(CourseTermCreateDto create, string culture)
        {
            return Task.FromResult(
                new CourseTermDbo()
                {
                    ActiveFrom = create.ActiveFrom,
                    ActiveTo = create.ActiveTo,
                    ClassRoomId = create.ClassRoomId ?? Guid.Empty,
                    CourseId = create.CourseId,
                    Friday = create.Friday,
                    MaximumStudent = create.MaximumStudents,
                    MinimumStudent = create.MinimumStudents,
                    Monday = create.Monday,
                    Price = create.Price,
                    RegistrationFrom = create.RegistrationFrom,
                    RegistrationTo = create.RegistrationTo,
                    Sale = create.Sale,
                    Saturday = create.Saturday,
                    Sunday = create.Sunday,
                    Thursday = create.Thursday,
                    TimeFromId = create.TimeFromId,
                    TimeToId = create.TimeToId,
                    Tuesday = create.Tuesday,
                    Wednesday = create.Wednesday,
                    OrganizationStudyHourId = create.OrganizationStudyHourId
                }
            );
        }
    }
}
