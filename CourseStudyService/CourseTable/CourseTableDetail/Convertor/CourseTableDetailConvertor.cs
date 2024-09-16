using CourseStudyService.CourseTable.CourseTableDetail.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableDetail.Convertor
{
    public class CourseTableDetailConvertor : ICourseTableDetailConvertor
    {
        public Task<CourseTableDetailDto> ConvertToWebModel(CourseTableDbo detail, List<string> culture)
        {
            return Task.FromResult(new CourseTableDetailDto()
            {
                Id = detail.Id,
                Img = detail.Image
            });
        }
    }
}
