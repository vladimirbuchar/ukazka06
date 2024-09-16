using Core.Base.Command.Update;
using CourseStudyService.CourseTable.CourseTableUpdate.Dto;
using Model.Edu.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableUpdate.Command
{
    public interface ICourseTableUpdateCommand : IBaseUpdateCommand<CourseTableDbo, CourseTableUpdateDto>
    {
    }
}