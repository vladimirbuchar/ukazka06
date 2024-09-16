using Core.Base.Command.Detail;
using CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Convertor;
using CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Dto;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryDetail.Command
{
    public class StudentTestSummaryDetailCommand : BaseDetailCommand<StudentTestSummaryDbo, IStudentTestSummaryRepository, StudentTestSummaryDetailDto, IStudentTestSummaryDetailConvertor>, IStudentTestSummaryDetailCommand
    {
        public StudentTestSummaryDetailCommand(IStudentTestSummaryRepository repository, IStudentTestSummaryDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
