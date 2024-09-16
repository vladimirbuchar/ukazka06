using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionCreate.Convertor
{
    public class StudentTestSummaryQuestionCreateConvertor : IStudentTestSummaryQuestionCreateConvertor
    {
        public Task<StudentTestSummaryQuestionDbo> ConvertToBussinessEntity(StudentTestSummaryQuestionCreateDto create, string culture)
        {
            return Task.FromResult(new StudentTestSummaryQuestionDbo()
            {
                Question = create.Question,
                AnswerModeId = create.AnswerModeId,
                IsAutomaticEvaluate = create.IsAutomaticEvaluate,
                Position = create.Position,
                TestQuestionId = create.TestQuestionId,
                FilePath = create.FilePath,
                QuestionModeId = create.QuestionModeId,
            });
        }
    }
}
