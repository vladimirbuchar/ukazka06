using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionDetail.Convertor
{
    public class StudentTestSummaryQuestionDetailConvertor : IStudentTestSummaryQuestionDetailConvertor
    {
        public Task<StudentTestSummaryQuestionDetailDto> ConvertToWebModel(StudentTestSummaryQuestionDbo detail, List<string> culture)
        {
            return Task.FromResult(new StudentTestSummaryQuestionDetailDto()
            {
                AnswerMode = detail.AnswerMode.SystemIdentificator,
                Id = detail.Id,
            });
        }
    }
}
