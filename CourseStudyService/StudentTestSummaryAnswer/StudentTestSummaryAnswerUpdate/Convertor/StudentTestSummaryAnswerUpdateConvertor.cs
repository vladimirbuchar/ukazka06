using CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Dto;
using Model.Edu.StudentTestSummaryAnswer;

namespace CourseStudyService.StudentTestSummaryAnswer.StudentTestSummaryAnswerUpdate.Convertor
{
    public class StudentTestSummaryAnswerUpdateConvertor : IStudentTestSummaryAnswerUpdateConvertor
    {
        public Task<StudentTestSummaryAnswerDbo> ConvertToBussinessEntity(StudentTestSummaryAnswerUpdateDto update, StudentTestSummaryAnswerDbo entity, string culture)
        {
            entity.UserTestAnswer = update.Answer;
            entity.FilePath = update.FilePath;
            entity.UserAnswer = true;
            entity.IsTrueAnswer = update.IsTrue;
            return Task.FromResult(entity);
        }
    }
}
