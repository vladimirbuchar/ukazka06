using CourseService.CourseTerm.CourseTermUpdate.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermUpdate.Convertor
{
    public class CourseTermUpdateConvertor : ICourseTermUpdateConvertor
    {
        public Task<CourseTermDbo> ConvertToBussinessEntity(CourseTermUpdateDto update, CourseTermDbo entity, string culture)
        {
            entity.ActiveFrom = update.ActiveFrom;
            entity.ActiveTo = update.ActiveTo;
            entity.ClassRoomId = update.ClassRoomId ?? Guid.Empty;
            entity.Price = update.Price;
            entity.Sale = update.Sale;
            entity.Friday = update.Friday;
            entity.Monday = update.Monday;
            entity.RegistrationFrom = update.RegistrationFrom;
            entity.RegistrationTo = update.RegistrationTo;
            entity.Saturday = update.Saturday;
            entity.MaximumStudent = update.MaximumStudents;
            entity.MinimumStudent = update.MinimumStudents;
            entity.Sunday = update.Sunday;
            entity.Thursday = update.Thursday;
            entity.TimeFromId = update.TimeFromId;
            entity.TimeToId = update.TimeToId;
            entity.Tuesday = update.Tuesday;
            entity.Wednesday = update.Wednesday;
            entity.OrganizationStudyHourId = update.OrganizationStudyHourId;
            return Task.FromResult(entity);
        }
    }
}
