using Core.Base.Command.List;
using Core.Base.Sort;
using CourseMaterialService.CourseLesson.CourseLessonList.Convertor;
using CourseMaterialService.CourseLesson.CourseLessonList.Dto;
using CourseMaterialService.CourseLesson.CourseLessonList.Filter;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Sort;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;
using Repository.CourseMaterial;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseMaterialService.CourseLesson.CourseLessonList.Command
{
    public class CourseLessonListService
        : BaseListCommand<CourseLessonDbo, ICourseLessonRepository, CourseLessonListDto, ICourseLessonListConvertor, CourseLessonFilter>,
            ICourseLessonListService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;

        public CourseLessonListService(
            ICourseMaterialRepository courseMaterialRepository,
            ICourseLessonRepository repository,
            ICourseLessonListConvertor convertor
        )
            : base(repository, convertor)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }

        protected override Expression<Func<CourseLessonDbo, bool>> PrepareSqlFilter(CourseLessonFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseLessonDbo), "courseLesson");
            Expression expression = Expression.Constant(true); // Start with a true expression

            expression = FilterTranslation<CourseLessonTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(CourseLessonTranslationDbo.Name),
                nameof(CourseLessonTranslationDbo.Culture),
                nameof(CourseLessonDbo.CourseLessonTranslations)
            );

            return Expression.Lambda<Func<CourseLessonDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<CourseLessonDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == CourseMaterialSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseLessonDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseLessonDbo.CourseLessonTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(CourseLessonTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(CourseLessonTranslationDbo.Name));
                Expression<Func<CourseLessonDbo, object>> lambda = Expression.Lambda<Func<CourseLessonDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseLessonDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }

        public override Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return _courseMaterialRepository.GetOrganizationId(objectId);
        }
    }
}
