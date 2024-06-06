using System.Collections.Generic;
using System.Linq;
using Core.Extension;
using EduServices.CourseTermTimeTable.Dto;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.CourseTermDate;

namespace EduServices.CourseTermTimeTable.Convertor
{
    public class CourseTermTimeTableConvertor : ICourseTermTimeTableConvertor
    {
        public HashSet<CourseTermTimeTableListDto> ConvertToWebModel(HashSet<CourseTermDateDbo> getTimeTables, string culture)
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
                    Lector = string.Format("{0} {1} {2}", x.UserInOrganization.User.Person.FirstName, x.UserInOrganization.User.Person.SecondName, x.UserInOrganization.User.Person.LastName)
                        .IsNullOrEmptyWithTrim()
                        ? x.UserInOrganization.User.UserEmail
                        : string.Format("{0} {1} {2}", x.UserInOrganization.User.Person.FirstName, x.UserInOrganization.User.Person.SecondName, x.UserInOrganization.User.Person.LastName)
                })
                .ToHashSet();
        }
    }
}
