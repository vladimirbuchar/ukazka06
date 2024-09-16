using Core.Extension;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.CourseTermTimeTableList.Dto;

namespace CourseService.CourseTermTimeTable.CourseTermTimeTableList.Convertor
{
    public class CourseTermTimeTableListConvertor : ICourseTermTimeTableListConvertor
    {
        public Task<List<CourseTermTimeTableListDto>> ConvertToWebModel(List<CourseTermDateDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new CourseTermTimeTableListDto()
                {
                    Date = x.Date.Value,
                    DayOfWeek = x.DayOfWeek,
                    Id = x.Id,
                    IsCanceled = x.IsCanceled,
                    TimeFrom = x.TimeFrom.Value,
                    TimeTo = x.TimeTo.Value,
                    ClassRoom = x.ClassRoom.Name,
                    Lector = string.Format(
                                "{0} {1} {2}",
                                x.UserInOrganization.User.Person.FirstName,
                                x.UserInOrganization.User.Person.SecondName,
                                x.UserInOrganization.User.Person.LastName
                            )
                            .IsNullOrEmptyWithTrim()
                            ? x.UserInOrganization.User.UserEmail
                            : string.Format(
                                "{0} {1} {2}",
                                x.UserInOrganization.User.Person.FirstName,
                                x.UserInOrganization.User.Person.SecondName,
                                x.UserInOrganization.User.Person.LastName
                            )
                })
                    .ToList()
            );
        }
    }
}
