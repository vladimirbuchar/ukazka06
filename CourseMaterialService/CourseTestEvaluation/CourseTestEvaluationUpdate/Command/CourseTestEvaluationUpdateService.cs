using Core.Base.Command.Update;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Dto;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Validator;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Command
{
    public class CourseTestEvaluationUpdateService
        : BaseUpdateCommand<
            CourseTestEvaluationDbo,
            ICourseTestEvaluationRepository,
            CourseTestEvaluationUpdateDto,
            ICourseTestEvaluationUpdateConvertor,
            ICourseTestEvaluationUpdateValidator

        >,
            ICourseTestEvaluationUpdateService
    {
        public CourseTestEvaluationUpdateService(
            ICourseTestEvaluationRepository repository,
            ICourseTestEvaluationUpdateConvertor convertor,
            ICourseTestEvaluationUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
