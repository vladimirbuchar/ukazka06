using CourseService.CourseTerm.CourseTermList.Dto;
using Model.Edu.CourseTerm;

namespace CourseService.CourseTerm.CourseTermList.Convertor
{
    public class CourseTermListConvertor : ICourseTermListConvertor
    {
        public Task<List<CourseTermListDto>> ConvertToWebModel(List<CourseTermDbo> list, List<string> culture)
        {
            List<CourseTermListDto> result = list.Select(item => new CourseTermListDto()
            {
                Branch = item.ClassRoom.Branch.Name,
                ClassRoom = item.ClassRoom.Name,
                Id = item.Id,
                TimeFrom = item.TimeFrom.Value,
                TimeTo = item.TimeTo.Value,
                ActiveFrom = item.ActiveFrom,
                ActiveTo = item.ActiveTo,
                Monday = item.Monday,
                Saturday = item.Saturday,
                Sunday = item.Sunday,
                Thursday = item.Thursday,
                Tuesday = item.Tuesday,
                Wednesday = item.Wednesday,
                Friday = item.Friday,
                BranchId = item.ClassRoom.BranchId,
                ClassRoomId = item.ClassRoomId
            })
                .ToList();
            return Task.FromResult(result);
        }
    }
}
