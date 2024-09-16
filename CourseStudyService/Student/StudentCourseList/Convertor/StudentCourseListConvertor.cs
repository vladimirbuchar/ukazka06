using CourseStudyService.Student.StudentCourseList.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseList.Convertor
{
    public class StudentCourseListConvertor : IStudentCourseListConvertor
    {
        public Task<List<StudentCourseListDto>> ConvertToWebModel(List<CourseStudentDbo> list, List<string> culture)
        {
            return Task.FromResult(list
               .Select(item => new StudentCourseListDto()
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
                   CourseTermId = item.CourseTermId,
                   CourseFinish = item.CourseFinish,
                   ClassRoom = item.CourseTerm.ClassRoom.Name,
               })
               .ToList());
        }
    }
}
