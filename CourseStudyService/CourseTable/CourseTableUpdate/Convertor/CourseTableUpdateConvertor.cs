using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Convertor
{
    public class CourseTableUpdateConvertor : ICourseTableUpdateConvertor
    {
        public Task<CourseTableDbo> ConvertToBussinessEntity(CourseTableUpdateDto update, CourseTableDbo entity, string culture)
        {
            entity.Image = update.Img;
            return Task.FromResult(entity);
        }
    }
}
