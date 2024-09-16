using Core.Base.Validator;
using CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Dto;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationUpdate.Validator
{
    public class StudentEvaluationUpdateValidator : BaseUpdateValidator<StudentEvaluationDbo, IStudentEvaluationRepository, StudentEvaluationUpdateDto>, IStudentEvaluationUpdateValidator
    {
        public StudentEvaluationUpdateValidator(IStudentEvaluationRepository repository) : base(repository)
        {
        }
    }
}
