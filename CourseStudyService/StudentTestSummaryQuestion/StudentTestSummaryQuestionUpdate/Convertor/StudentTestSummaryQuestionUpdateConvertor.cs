using CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Dto;
using Model.Edu.StudentTestSummaryQuestion;

namespace CourseStudyService.StudentTestSummaryQuestion.StudentTestSummaryQuestionUpdate.Convertor
{
    public class StudentTestSummaryQuestionUpdateConvertor : IStudentTestSummaryQuestionUpdateConvertor
    {
        public Task<StudentTestSummaryQuestionDbo> ConvertToBussinessEntity(StudentTestSummaryQuestionUpdateDto update, StudentTestSummaryQuestionDbo entity, string culture)
        {
            entity.Score = update.Score;
            entity.IsTrue = update.IsTrue;
            entity.StudentTestSummaryId = update.StudentTestSummaryId;
            return Task.FromResult(entity);
        }
    }
}
