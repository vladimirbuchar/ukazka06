using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionList.Convertor
{
    public class StudentTestSummaryQuestionListConvertor : IStudentTestSummaryQuestionListConvertor
    {
        public Task<List<StudentTestSummaryQuestionListDto>> ConvertToWebModel(List<StudentTestSummaryQuestionDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentTestSummaryQuestionListDto()
            {
                Id = x.Id,
                IsAutomaticEvaluate = x.IsAutomaticEvaluate,
                Score = x.Score,
            }).ToList());
        }
    }
}
