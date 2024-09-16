using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.CourseStudy.GetAllStudentTestResult.Convertor;
using CourseStudyService.CourseStudy.GetAllStudentTestResult.Dto;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.CourseStudy.GetAllStudentTestResult.Command
{
    public class GetAllStudentTestResultCommand : BaseListCommand<StudentTestSummaryDbo, IStudentTestSummaryRepository, StudentTestResultListDto, IGetAllStudentTestResultConvertor, RequestFilter>, IGetAllStudentTestResultCommand
    {
        public GetAllStudentTestResultCommand(IStudentTestSummaryRepository repository, IGetAllStudentTestResultConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
