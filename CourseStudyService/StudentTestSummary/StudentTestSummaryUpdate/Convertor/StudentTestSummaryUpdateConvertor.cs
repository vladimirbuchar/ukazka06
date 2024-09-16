using CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Dto;
using Model.Edu.StudentTestSummary;

namespace CourseStudyService.StudentTestSummary.StudentTestSummaryUpdate.Convertor
{
    public class StudentTestSummaryUpdateConvertor : IStudentTestSummaryUpdateConvertor
    {
        public Task<StudentTestSummaryDbo> ConvertToBussinessEntity(StudentTestSummaryUpdateDto update, StudentTestSummaryDbo entity, string culture)
        {
            entity.Finish = DateTime.Now;
            entity.Score = update.SumScore;
            entity.IsSucess = update.IsSucess;
            return Task.FromResult(entity);
        }
    }
}
