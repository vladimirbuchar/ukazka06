using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Dto;
using Model.Edu.CourseTestEvaluation;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Convertor
{
    public class CourseTestEvaluationListConvertor : ICourseTestEvaluationListConvertor
    {
        public Task<List<CourseTestEvaluationListDto>> ConvertToWebModel(List<CourseTestEvaluationDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new CourseTestEvaluationListDto()
                {
                    Evaluation = item.Evaluation,
                    PointFrom = item.PointFrom,
                    Id = item.Id,
                    PointTo = item.PointTo,
                })
                    .ToList()
            );
        }
    }
}
