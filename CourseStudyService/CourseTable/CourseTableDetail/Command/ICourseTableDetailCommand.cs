using Core.Base.Command.Detail;
using CourseStudyService.CourseTable.CourseTableDetail.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableDetail.Command
{
    public interface ICourseTableDetailCommand : IBaseDetailCommand<CourseTableDbo, CourseTableDetailDto>
    {
    }
}