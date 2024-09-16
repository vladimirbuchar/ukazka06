using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Convertor
{
    public class StudentEvaluationUpdateConvertor : IStudentEvaluationUpdateConvertor
    {
        public Task<StudentEvaluationDbo> ConvertToBussinessEntity(StudentEvaluationUpdateDto update, StudentEvaluationDbo entity, string culture)
        {
            entity.Evaluation = update.Evaluation;
            return Task.FromResult(entity);
        }
    }
}
