using CourseService.CourseTerm.CourseTermDetail.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermDetail.Convertor
{
    public class CourseTermDetailConvertor : ICourseTermDetailConvertor
    {
        public Task<CourseTermDetailDto> ConvertToWebModel(CourseTermDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new CourseTermDetailDto()
                {
                    ActiveFrom = detail.ActiveFrom,
                    Id = detail.Id,
                    Wednesday = detail.Wednesday,
                    ActiveTo = detail.ActiveTo,
                    ClassRoomId = detail.ClassRoomId,
                    BranchId = detail.ClassRoom.BranchId,
                    Price = detail.Price,
                    Sale = detail.Sale,
                    Friday = detail.Friday,
                    MaximumStudent = detail.MaximumStudent,
                    MinimumStudent = detail.MinimumStudent,
                    Monday = detail.Monday,
                    RegistrationFrom = detail.RegistrationFrom,
                    RegistrationTo = detail.RegistrationTo,
                    Saturday = detail.Saturday,
                    Sunday = detail.Sunday,
                    Thursday = detail.Thursday,
                    TimeFromId = detail.TimeFromId,
                    TimeToId = detail.TimeToId,
                    Tuesday = detail.Tuesday,
                    OrganizationStudyHourId = detail.OrganizationStudyHourId
                }
            );
        }
    }
}
