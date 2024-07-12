using Core.Base.Service;
using Model.Edu.StudentGroup;
using Repository.StudentGroupRepository;
using Services.StudentGroup.Convertor;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Filter;
using Services.StudentGroup.Sort;
using Services.StudentGroup.Validator;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.StudentGroup.Service
{
    public class StudentGroupService(
        IStudentGroupValidator validator,
        IStudentGroupRepository studentGroupRepository,
        IStudentGroupConvertor studentGroupConvertor
    )
        : BaseService<
            IStudentGroupRepository,
            StudentGroupDbo,
            IStudentGroupConvertor,
            IStudentGroupValidator,
            StudentGroupCreateDto,
            StudentGroupInOrganizationListDto,
            StudentGroupDetailDto,
            StudentGroupUpdateDto,
            StudentGroupFilter
        >(studentGroupRepository, studentGroupConvertor, validator),
            IStudentGroupService
    {
        protected override Expression<Func<StudentGroupDbo, bool>> PrepareSqlFilter(StudentGroupFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(StudentGroupDbo), "studentGroup");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterTranslation<StudentGroupTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(StudentGroupTranslationDbo.Name),
                nameof(StudentGroupTranslationDbo.Culture),
                nameof(StudentGroupDbo.StudentGroupTranslations)
            );
            return Expression.Lambda<Func<StudentGroupDbo, bool>>(expression, parameter);
        }

        protected override Expression<Func<StudentGroupDbo, object>> PrepareSort(string columnName, string culture)
        {
            if (columnName == StudentGroupSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(StudentGroupDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(StudentGroupDbo.StudentGroupTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(StudentGroupTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(StudentGroupTranslationDbo.Name));
                Expression<Func<StudentGroupDbo, object>> lambda = Expression.Lambda<Func<StudentGroupDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }
    }
}
