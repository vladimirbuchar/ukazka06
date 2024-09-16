using CourseStudyService.Lector.LectorCourseList.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorCourseList.Convertor
{
    public class LectorCourseListConvertor : ILectorCourseListConvertor
    {
        public Task<List<LectorCourseListDto>> ConvertToWebModel(List<CourseLectorDbo> list, List<string> culture)
        {
            return Task.FromResult(list
                .Select(item => new LectorCourseListDto()
                {
                    ActiveFrom = item.CourseTerm.ActiveFrom.Value,
                    ActiveTo = item.CourseTerm.ActiveTo.Value,
                    BranchName = item.CourseTerm.ClassRoom.Branch.Name,
                    CourseName = item.CourseTerm.ClassRoom.Name,
                    Friday = item.CourseTerm.Friday,
                    Id = item.Id,
                    Monday = item.CourseTerm.Monday,
                    Saturday = item.CourseTerm.Saturday,
                    Sunday = item.CourseTerm.Sunday,
                    Thursday = item.CourseTerm.Thursday,
                    TimeFrom = item.CourseTerm.TimeFrom.Value,
                    TimeTo = item.CourseTerm.TimeTo.Value,
                    Tuesday = item.CourseTerm.Tuesday,
                    UserId = item.UserInOrganizationId,
                    Wednesday = item.CourseTerm.Wednesday,
                    OrganizationName = item.CourseTerm.ClassRoom.Branch.Organization.Name,
                    CourseTermId = item.CourseTermId
                })
                .ToList());
        }
    }
}
