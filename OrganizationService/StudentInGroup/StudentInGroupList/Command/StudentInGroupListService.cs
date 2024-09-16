using Core.Base.Command.List;
using Core.Base.Sort;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupList.Convertor;
using OrganizationService.StudentInGroup.StudentInGroupList.Dto;
using OrganizationService.StudentInGroup.StudentInGroupList.Filter;
using Repository.StudentGroup;
using Repository.StudentInGroup;
using Services.StudentInGroup.StudentInGroupList.Sort;
using System.Linq.Expressions;
using System.Web.Helpers;

namespace OrganizationService.StudentInGroup.StudentInGroupList.Command
{
    public class StudentInGroupListService
        : BaseListCommand<StudentInGroupDbo, IStudentInGroupRepository, StudentInGroupListDto, IStudentInGroupListConvertor, StudentInGroupFilter>,
            IStudentInGroupListService
    {
        private readonly IStudentGroupRepository _studentGroupRepository;

        public StudentInGroupListService(
            IStudentGroupRepository studentGroupRepository,
            IStudentInGroupRepository repository,
            IStudentInGroupListConvertor convertor
        )
            : base(repository, convertor)
        {
            _studentGroupRepository = studentGroupRepository;
        }

        protected override Expression<Func<StudentInGroupDbo, bool>> PrepareSqlFilter(StudentInGroupFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentInGroupDbo), "StudentInGroup");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterString(
                filter.FirstName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.FirstName)
            );
            expression = FilterString(
                filter.SecondName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.SecondName)
            );
            expression = FilterString(
                filter.LastName,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person),
                nameof(StudentInGroupDbo.UserInOrganization.User.Person.LastName)
            );
            expression = FilterString(
                filter.Email,
                parameter,
                expression,
                nameof(StudentInGroupDbo.UserInOrganization),
                nameof(StudentInGroupDbo.UserInOrganization.User),
                nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail)
            );
            return Expression.Lambda<Func<StudentInGroupDbo, bool>>(expression, parameter);
        }

        protected override List<BaseSort<StudentInGroupDbo>> PrepareSort(
            string columnName,
            string culture,
            SortDirection sortDirection = SortDirection.Ascending
        )
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentInGroupDbo), "x");
            MemberExpression property = Expression.Property(parameter, nameof(StudentInGroupDbo.UserInOrganization));
            MemberExpression property1 = Expression.Property(property, nameof(StudentInGroupDbo.UserInOrganization.User));
            if (columnName == StudentInGroupSort.FirstName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.FirstName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<StudentInGroupDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == StudentInGroupSort.SecondName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.SecondName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<StudentInGroupDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == StudentInGroupSort.LastName.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.Person));
                MemberExpression property3 = Expression.Property(property2, nameof(StudentInGroupDbo.UserInOrganization.User.Person.LastName));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property3, typeof(object)),
                    parameter
                );
                return [new BaseSort<StudentInGroupDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            if (columnName == StudentInGroupSort.Email.ToString())
            {
                MemberExpression property2 = Expression.Property(property1, nameof(StudentInGroupDbo.UserInOrganization.User.UserEmail));
                Expression<Func<StudentInGroupDbo, object>> lambda = Expression.Lambda<Func<StudentInGroupDbo, object>>(
                    Expression.Convert(property2, typeof(object)),
                    parameter
                );
                return [new BaseSort<StudentInGroupDbo>() { Sort = lambda, SortDirection = sortDirection }];
            }
            return base.PrepareSort(columnName, culture);
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _studentGroupRepository.GetOrganizationId(objectId);
        }
    }
}
