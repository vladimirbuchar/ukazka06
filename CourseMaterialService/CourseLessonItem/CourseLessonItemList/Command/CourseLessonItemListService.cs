using Core.Base.Command.List;
using Core.Base.Sort;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Convertor;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Dto;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Filter;
using CourseMaterialService.CourseLessonItem.CourseLessonItemList.Sort;
using Model.Edu.CourseLessonItem;
using Repository.CourseLesson;
using Repository.CourseLessonItem;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemList.Command
{
    public class CourseLessonItemListService
        : BaseListCommand<
            CourseLessonItemDbo,
            ICourseLessonItemRepository,
            CourseLessonItemListDto,
            ICourseLessonItemListConvertor,
            CourseLessonItemFilter
        >,
            ICourseLessonItemListService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;

        public CourseLessonItemListService(
            ICourseLessonRepository courseLessonRepository,
            ICourseLessonItemRepository repository,
            ICourseLessonItemListConvertor convertor
        )
            : base(repository, convertor)
        {
            _courseLessonRepository = courseLessonRepository;
        }

        protected override Expression<Func<CourseLessonItemDbo, bool>> PrepareSqlFilter(CourseLessonItemFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseLessonItemDbo), "courseLessonItem");
            Expression expression = Expression.Constant(true); // Start with a true expression

            expression = FilterTranslation<CourseLessonItemTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(CourseLessonItemTranslationDbo.Name),
                nameof(CourseLessonItemTranslationDbo.Culture),
                nameof(CourseLessonItemDbo.CourseLessonItemTranslations)
            );

            return Expression.Lambda<Func<CourseLessonItemDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<CourseLessonItemDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == CourseLessonItemSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseLessonItemDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseLessonItemDbo.CourseLessonItemTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(CourseLessonItemTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(CourseLessonItemTranslationDbo.Name));
                Expression<Func<CourseLessonItemDbo, object>> lambda = Expression.Lambda<Func<CourseLessonItemDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseLessonItemDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseLessonRepository.GetOrganizationId(objectId);
        }
    }
}
