using Core.Base.Command.List;
using Core.Base.Sort;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Dto;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Filter;
using CourseMaterialService.CourseMaterial.CourseMaterialList.Sort;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace CourseMaterialService.CourseMaterial.CourseMaterialList.Command
{
    public class CourseMaterialListService
        : BaseListCommand<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialListDto, ICourseMaterialListConvertor, CourseMaterialFilter>,
            ICourseMaterialListService
    {
        public CourseMaterialListService(ICourseMaterialRepository repository, ICourseMaterialListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<CourseMaterialDbo, bool>> PrepareSqlFilter(CourseMaterialFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseMaterialDbo), "courseMaterial");
            Expression expression = Expression.Constant(true); // Start with a true expression

            expression = FilterTranslation<CourseMaterialTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(CourseMaterialTranslationDbo.Name),
                nameof(CourseMaterialTranslationDbo.Culture),
                nameof(CourseMaterialDbo.CourseMaterialTranslation)
            );

            return Expression.Lambda<Func<CourseMaterialDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<CourseMaterialDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            if (columnName == CourseMaterialSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseMaterialDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseMaterialDbo.CourseMaterialTranslation));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(CourseMaterialTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(CourseMaterialTranslationDbo.Name));
                Expression<Func<CourseMaterialDbo, object>> lambda = Expression.Lambda<Func<CourseMaterialDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return [new BaseSort<CourseMaterialDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
