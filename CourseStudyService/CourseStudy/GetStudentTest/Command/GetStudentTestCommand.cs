using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.CourseStudy.GetStudentTest.Convertor;
using CourseStudyService.CourseStudy.GetStudentTest.Dto;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetStudentTest.Command
{
    public class GetStudentTestCommand : BaseListCommand<StudentTestSummaryDbo, IStudentTestSummaryRepository, StudentTestListDto, IGetStudentTestConvertor, RequestFilter>, IGetStudentTestCommand
    {
        public GetStudentTestCommand(IStudentTestSummaryRepository repository, IGetStudentTestConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
