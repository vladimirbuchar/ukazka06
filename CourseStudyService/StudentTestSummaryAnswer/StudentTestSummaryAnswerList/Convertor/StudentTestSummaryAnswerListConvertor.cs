using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerList.Convertor
{
    public class StudentTestSummaryAnswerListConvertor : IStudentTestSummaryAnswerListConvertor
    {
        public Task<List<StudentTestSummaryAnswerListDto>> ConvertToWebModel(List<StudentTestSummaryAnswerDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentTestSummaryAnswerListDto()
            {
                Id = x.Id,
                UserAnswer = x.UserAnswer,
                IsTrueAnswer = x.IsTrueAnswer,
            }).ToList());
        }
    }
}
