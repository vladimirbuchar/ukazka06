using Core.Base.Command.Detail;
using CourseStudyService.CourseTable.CourseTableDetail.Convertor;
using CourseStudyService.CourseTable.CourseTableDetail.Dto;
using Model.Edu.CourseTable;
using Repository.CourseTable;

namespace CourseStudyService.CourseTable.CourseTableDetail.Command
{
    public class CourseTableDetailCommand : BaseDetailCommand<CourseTableDbo, ICourseTableRepository, CourseTableDetailDto, ICourseTableDetailConvertor>, ICourseTableDetailCommand
    {
        public CourseTableDetailCommand(ICourseTableRepository repository, ICourseTableDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
