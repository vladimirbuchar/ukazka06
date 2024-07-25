using Model.Edu.CourseTestEvaluation;
using Services.CourseTestEvaluation.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseTestEvaluation.Convertor
{
    public class CourseTestEvaluationConvertor() : ICourseTestEvaluationConvertor
    {
        public Task<CourseTestEvaluationDbo> ConvertToBussinessEntity(CourseTestEvaluationUpdateDto update, CourseTestEvaluationDbo entity, string culture)
        {
            entity.PointFrom = update.PointFrom;
            entity.PointTo = update.PointTo;
            entity.Evaluation = update.Evaluation;
            return Task.FromResult(entity);
        }

        public Task<CourseTestEvaluationDbo> ConvertToBussinessEntity(CourseTestEvaluationCreateDto create, string culture)
        {
            return Task.FromResult(new CourseTestEvaluationDbo()
            {
                Evaluation = create.Evaluation,
                PointFrom = create.PointFrom,
                PointTo = create.PointTo,
                CourseTestId = create.TestId
            });
        }

        public Task<List<CourseTestEvaluationListDto>> ConvertToWebModel(List<CourseTestEvaluationDbo> list, string culture)
        {
            return Task.FromResult(list.Select(item => new CourseTestEvaluationListDto()
            {
                Evaluation = item.Evaluation,
                PointFrom = item.PointFrom,
                Id = item.Id,
                PointTo = item.PointTo,
            })
                .ToList());
        }

        public Task<CourseTestEvaluationDetailDto> ConvertToWebModel(CourseTestEvaluationDbo detail, string culture)
        {
            return Task.FromResult(new CourseTestEvaluationDetailDto()
            {
                Evaluation = detail.Evaluation,
                Id = detail.Id,
                PointFrom = detail.PointFrom,
                PointTo = detail.PointTo
            });
        }
    }
}
