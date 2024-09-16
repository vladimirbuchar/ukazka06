using Core.Base.Validator;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Dto;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Validator
{
    public class CourseTestEvaluationUpdateValidator
        : BaseUpdateValidator<CourseTestEvaluationDbo, ICourseTestEvaluationRepository, CourseTestEvaluationUpdateDto>,
            ICourseTestEvaluationUpdateValidator
    {
        public CourseTestEvaluationUpdateValidator(ICourseTestEvaluationRepository repository)
            : base(repository) { }
    }
}
