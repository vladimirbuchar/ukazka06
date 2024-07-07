using System.Collections.Generic;
using System.Linq;
using Model.Edu.CourseTestEvaluation;
using Services.CourseTestEvaluation.Dto;

namespace Services.CourseTestEvaluation.Convertor
{
    public class CourseTestEvaluationConvertor() : ICourseTestEvaluationConvertor
    {
        public CourseTestEvaluationDbo ConvertToBussinessEntity(CourseTestEvaluationUpdateDto update, CourseTestEvaluationDbo entity, string culture)
        {
            entity.PointFrom = update.PointFrom;
            entity.PointTo = update.PointTo;
            entity.Evaluation = update.Evaluation;
            return entity;
        }

        public CourseTestEvaluationDbo ConvertToBussinessEntity(CourseTestEvaluationCreateDto create, string culture)
        {
            return new CourseTestEvaluationDbo()
            {
                Evaluation = create.Evaluation,
                PointFrom = create.PointFrom,
                PointTo = create.PointTo,
                CourseTestId = create.TestId
            };
        }

        public HashSet<CourseTestEvaluationListDto> ConvertToWebModel(HashSet<CourseTestEvaluationDbo> list, string culture)
        {
            return list.Select(item => new CourseTestEvaluationListDto()
                {
                    Evaluation = item.Evaluation,
                    PointFrom = item.PointFrom,
                    Id = item.Id,
                    PointTo = item.PointTo,
                })
                .ToHashSet();
        }

        public CourseTestEvaluationDetailDto ConvertToWebModel(CourseTestEvaluationDbo detail, string culture)
        {
            return new CourseTestEvaluationDetailDto()
            {
                Evaluation = detail.Evaluation,
                Id = detail.Id,
                PointFrom = detail.PointFrom,
                PointTo = detail.PointTo
            };
        }
    }
}
