using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerCreate.Convertor
{
    public class StudentTestSummaryAnswerCreateConvertor : IStudentTestSummaryAnswerCreateConvertor
    {
        public Task<StudentTestSummaryAnswerDbo> ConvertToBussinessEntity(StudentTestSummaryAnswerCreateDto create, string culture)
        {
            return Task.FromResult(new StudentTestSummaryAnswerDbo()
            {
                StudentTestSummaryQuestionId = create.StudentTestSummaryQuestionId,
                UserTestAnswer = create.Answer,
                IsTrueAnswer = create.IsTrueAnswer,
                TestQuestionAnswerId = create.TestQuestionAnswerId,
                FilePath = create.FilePath
            });
        }
    }
}
