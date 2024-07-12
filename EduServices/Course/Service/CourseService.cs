using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Certificate;
using Model.Edu.Course;
using Model.Edu.CourseMaterial;
using Model.Edu.Message;
using Repository.CourseRepository;
using Services.Course.Convertor;
using Services.Course.Dto;
using Services.Course.Filter;
using Services.Course.Sort;
using Services.Course.Validator;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Course.Service
{
    public class CourseService(ICourseRepository courseRepository, ICourseConvertor courseConvertor, ICourseValidator validator)
        : BaseService<
            ICourseRepository,
            CourseDbo,
            ICourseConvertor,
            ICourseValidator,
            CourseCreateDto,
            CourseListDto,
            CourseDetailDto,
            CourseUpdateDto,
            CourseFilter
        >(courseRepository, courseConvertor, validator),
            ICourseService
    {
        protected override Expression<Func<CourseDbo, bool>> PrepareSqlFilter(CourseFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "course");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.IsPrivateCourse, parameter, expression, nameof(CourseDbo.IsPrivateCourse));
            expression = FilterBool(filter.AutomaticGenerateCertificate, parameter, expression, nameof(CourseDbo.AutomaticGenerateCertificate));
            expression = FilterBool(filter.SendEmail, parameter, expression, nameof(CourseDbo.SendEmail));
            expression = FilterBool(filter.CourseWithLector, parameter, expression, nameof(CourseDbo.CourseWithLector));
            expression = FilterInt(filter.Sale, parameter, expression, nameof(CourseDbo.Sale));
            expression = FilterInt(filter.MaximumStudent, parameter, expression, nameof(CourseDbo.MaximumStudent));
            expression = FilterInt(filter.MinimumStudent, parameter, expression, nameof(CourseDbo.MinimumStudent));
            expression = FilterDouble(filter.Price, parameter, expression, nameof(CourseDbo.MinimumStudent));
            expression = FilterGuid(filter.CourseTypeId, parameter, expression, nameof(CourseDbo.CourseTypeId));
            expression = FilterGuid(filter.CourseStatusId, parameter, expression, nameof(CourseDbo.CourseStatusId));
            expression = FilterGuid(filter.CertificateId, parameter, expression, nameof(CourseDbo.CertificateId));
            expression = FilterGuid(filter.CourseMaterialId, parameter, expression, nameof(CourseDbo.CourseMaterialId));
            expression = FilterGuid(filter.SendMessageId, parameter, expression, nameof(CourseDbo.SendMessageId));
            expression = FilterTranslation<CourseTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(CourseTranslationDbo.Name),
                nameof(CourseTranslationDbo.Culture),
                nameof(CourseDbo.CourseTranslations)
            );

            return Expression.Lambda<Func<CourseDbo, bool>>(expression, parameter);
        }

        protected override Expression<Func<CourseDbo, object>> PrepareSort(string columnName, string culture)
        {

            if (columnName == CourseSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseDbo.CourseTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(CourseTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(CourseTranslationDbo.Name));
                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            else if (columnName == CourseSort.CourseType.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseDbo.CourseType));
                MemberExpression nameProperty = Expression.Property(property, nameof(CourseTypeDbo.Name));
                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }

            else if (columnName == CourseSort.CourseStatus.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(CourseDbo.CourseStatus));
                MemberExpression nameProperty = Expression.Property(property, nameof(CourseStatusDbo.Name));
                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            else if (columnName == CourseSort.Certificate.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression courseMaterialProperty = Expression.Property(parameter, nameof(CourseDbo.Certificate));
                MemberExpression courseMaterialTranslationProperty = Expression.Property(courseMaterialProperty, nameof(CertificateDbo.CertificateTranslations));

                // Filtrujeme podle culture
                ParameterExpression translationParameter = Expression.Parameter(typeof(CertificateTranslationDbo), "t");
                MemberExpression cultureProperty = Expression.Property(translationParameter, nameof(CertificateTranslationDbo.Culture));
                MemberExpression systemIdentifcator = Expression.Property(cultureProperty, nameof(CertificateTranslationDbo.Culture.SystemIdentificator));

                ConstantExpression cultureConstant = Expression.Constant(culture);
                BinaryExpression cultureEqual = Expression.Equal(systemIdentifcator, cultureConstant);

                MethodCallExpression whereCall = Expression.Call(
                    typeof(Enumerable),
                    "Where",
                    new Type[] { typeof(CertificateTranslationDbo) },
                    courseMaterialTranslationProperty,
                    Expression.Lambda<Func<CertificateTranslationDbo, bool>>(cultureEqual, translationParameter)
                );

                MethodCallExpression firstOrDefaultCall = Expression.Call(
                    typeof(Enumerable),
                    "FirstOrDefault",
                    new Type[] { typeof(CertificateTranslationDbo) },
                    whereCall
                );

                MemberExpression nameProperty = Expression.Property(firstOrDefaultCall, nameof(CertificateTranslationDbo.Name));

                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );

                return lambda;
            }
            else if (columnName == CourseSort.CourseMaterial.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression courseMaterialProperty = Expression.Property(parameter, nameof(CourseDbo.CourseMaterial));
                MemberExpression courseMaterialTranslationProperty = Expression.Property(courseMaterialProperty, nameof(CourseMaterialDbo.CourseMaterialTranslation));

                // Filtrujeme podle culture
                ParameterExpression translationParameter = Expression.Parameter(typeof(CourseMaterialTranslationDbo), "t");
                MemberExpression cultureProperty = Expression.Property(translationParameter, nameof(CourseMaterialTranslationDbo.Culture));
                MemberExpression systemIdentifcator = Expression.Property(cultureProperty, nameof(CourseMaterialTranslationDbo.Culture.SystemIdentificator));

                ConstantExpression cultureConstant = Expression.Constant(culture);
                BinaryExpression cultureEqual = Expression.Equal(systemIdentifcator, cultureConstant);

                MethodCallExpression whereCall = Expression.Call(
                    typeof(Enumerable),
                    "Where",
                    new Type[] { typeof(CourseMaterialTranslationDbo) },
                    courseMaterialTranslationProperty,
                    Expression.Lambda<Func<CourseMaterialTranslationDbo, bool>>(cultureEqual, translationParameter)
                );

                MethodCallExpression firstOrDefaultCall = Expression.Call(
                    typeof(Enumerable),
                    "FirstOrDefault",
                    new Type[] { typeof(CourseMaterialTranslationDbo) },
                    whereCall
                );

                MemberExpression nameProperty = Expression.Property(firstOrDefaultCall, nameof(CourseMaterialTranslationDbo.Name));

                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );

                return lambda;
            }
            else if (columnName == CourseSort.SendMessage.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(CourseDbo), "x");
                MemberExpression courseMaterialProperty = Expression.Property(parameter, nameof(CourseDbo.SendMessage));
                MemberExpression courseMaterialTranslationProperty = Expression.Property(courseMaterialProperty, nameof(MessageDbo.SendMessageTranslations));

                // Filtrujeme podle culture
                ParameterExpression translationParameter = Expression.Parameter(typeof(MessageTranslationDbo), "t");
                MemberExpression cultureProperty = Expression.Property(translationParameter, nameof(MessageTranslationDbo.Culture));
                MemberExpression systemIdentifcator = Expression.Property(cultureProperty, nameof(MessageTranslationDbo.Culture.SystemIdentificator));

                ConstantExpression cultureConstant = Expression.Constant(culture);
                BinaryExpression cultureEqual = Expression.Equal(systemIdentifcator, cultureConstant);

                MethodCallExpression whereCall = Expression.Call(
                    typeof(Enumerable),
                    "Where",
                    new Type[] { typeof(MessageTranslationDbo) },
                    courseMaterialTranslationProperty,
                    Expression.Lambda<Func<MessageTranslationDbo, bool>>(cultureEqual, translationParameter)
                );

                MethodCallExpression firstOrDefaultCall = Expression.Call(
                    typeof(Enumerable),
                    "FirstOrDefault",
                    new Type[] { typeof(MessageTranslationDbo) },
                    whereCall
                );

                MemberExpression nameProperty = Expression.Property(firstOrDefaultCall, nameof(MessageTranslationDbo.Subject));

                Expression<Func<CourseDbo, object>> lambda = Expression.Lambda<Func<CourseDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );

                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }

    }
}
