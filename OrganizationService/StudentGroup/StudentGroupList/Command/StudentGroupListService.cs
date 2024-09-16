using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupList.Convertor;
using OrganizationService.StudentGroup.StudentGroupList.Dto;
using OrganizationService.StudentGroup.StudentGroupList.Filter;
using Repository.StudentGroup;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.StudentGroup.StudentGroupList.Command
{
    public class StudentGroupListService
        : BaseListCommand<StudentGroupDbo, IStudentGroupRepository, StudentGroupListDto, IStudentGroupListConvertor, StudentGroupFilter>,
            IStudentGroupListService
    {
        public StudentGroupListService(IStudentGroupRepository repository, IStudentGroupListConvertor convertor)
            : base(repository, convertor) { }

        protected override Expression<Func<StudentGroupDbo, bool>> PrepareSqlFilter(StudentGroupFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentGroupDbo), "studentGroup");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(filter.Name, parameter, expression, nameof(StudentGroupDbo.Name));
            return Expression.Lambda<Func<StudentGroupDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<StudentGroupDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            return base.PrepareSort(columnName, culture);
        }
    }
}
