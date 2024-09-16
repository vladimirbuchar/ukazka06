using Core.Base.Command.List;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Convertor;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Dto;
using CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Filter;
using Model.Edu.CourseTestEvaluation;
using Repository.CourseTestEvaluation;
using Repository.Test;
using System.Linq.Expressions;

namespace CourseMaterialService.CourseTestEvaluation.CourseTestEvaluationList.Command
{
    public class CourseTestEvaluationListService
        : BaseListCommand<
            CourseTestEvaluationDbo,
            ICourseTestEvaluationRepository,
            CourseTestEvaluationListDto,
            ICourseTestEvaluationListConvertor,
            CourseTestEvaluationFilter
        >,
            ICourseTestEvaluationListService
    {
        private readonly ITestRepository _testRepository;

        public CourseTestEvaluationListService(
            ITestRepository testRepository,
            ICourseTestEvaluationRepository repository,
            ICourseTestEvaluationListConvertor convertor
        )
            : base(repository, convertor)
        {
            _testRepository = testRepository;
        }

        protected override Expression<Func<CourseTestEvaluationDbo, bool>> PrepareSqlFilter(CourseTestEvaluationFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseTestEvaluationDbo), "courseTestEvaluation");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Evaluation, parameter, expression, nameof(CourseTestEvaluationDbo.Evaluation));
            expression = FilterInt(filter.PointFrom, parameter, expression, nameof(CourseTestEvaluationDbo.PointFrom));
            expression = FilterInt(filter.PointTo, parameter, expression, nameof(CourseTestEvaluationDbo.PointTo));
            return Expression.Lambda<Func<CourseTestEvaluationDbo, bool>>(expression, parameter);
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _testRepository.GetOrganizationId(objectId);
        }
    }
}
