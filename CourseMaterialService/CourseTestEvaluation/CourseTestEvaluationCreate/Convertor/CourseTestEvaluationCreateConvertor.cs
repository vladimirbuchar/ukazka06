using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationCreate.Convertor
{
    public class CourseTestEvaluationCreateConvertor : ICourseTestEvaluationCreateConvertor
    {
        public Task<CourseTestEvaluationDbo> ConvertToBussinessEntity(CourseTestEvaluationCreateDto create, string culture)
        {
            return Task.FromResult(
                new CourseTestEvaluationDbo()
                {
                    Evaluation = create.Evaluation,
                    PointFrom = create.PointFrom,
                    PointTo = create.PointTo,
                    CourseTestId = create.TestId
                }
            );
        }
    }
}
