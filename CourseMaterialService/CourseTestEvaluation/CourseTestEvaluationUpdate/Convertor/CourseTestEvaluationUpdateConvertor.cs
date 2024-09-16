using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationUpdate.Convertor
{
    public class CourseTestEvaluationUpdateConvertor : ICourseTestEvaluationUpdateConvertor
    {
        public Task<CourseTestEvaluationDbo> ConvertToBussinessEntity(
            CourseTestEvaluationUpdateDto update,
            CourseTestEvaluationDbo entity,
            string culture
        )
        {
            entity.PointFrom = update.PointFrom;
            entity.PointTo = update.PointTo;
            entity.Evaluation = update.Evaluation;
            return Task.FromResult(entity);
        }
    }
}
