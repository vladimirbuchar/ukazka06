using CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationCreate.Convertor
{
    public class StudentEvaluationCreateConvertor : IStudentEvaluationCreateConvertor
    {
        public Task<StudentEvaluationDbo> ConvertToBussinessEntity(StudentEvaluationCreateDto create, string culture)
        {
            return Task.FromResult(
                new StudentEvaluationDbo()
                {
                    Evaluation = create.Evaluation,
                    CourseStudentId = create.CourseStudentId,
                    CourseTermId = create.CourseTermId,
                    Date = DateTime.Now
                }
            );
        }
    }
}
