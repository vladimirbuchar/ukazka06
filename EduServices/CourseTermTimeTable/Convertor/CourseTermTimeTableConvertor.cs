using System.Collections.Generic;
using System.Linq;
using Core.Extension;
using Model.Edu.ClassRoom;
using Model.Edu.CourseTermDate;
using Services.CourseTermTimeTable.Dto;

namespace Services.CourseTermTimeTable.Convertor
{
    public class CourseTermTimeTableConvertor : ICourseTermTimeTableConvertor
    {
        public List<CourseTermTimeTableListDto> ConvertToWebModel(List<CourseTermDateDbo> getTimeTables, string culture)
        {
            return getTimeTables
                .Select(x => new CourseTermTimeTableListDto()
                {
                    Date = x.Date,
                    DayOfWeek = x.DayOfWeek,
                    Id = x.Id,
                    IsCanceled = x.IsDeleted,
                    TimeFrom = x.TimeFrom.Value,
                    TimeTo = x.TimeTo.Value,
                    ClassRoom = x.ClassRoom.ClassRoomTranslations.FindTranslation(culture).Name,
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
                .ToList();
        }
    }
}
