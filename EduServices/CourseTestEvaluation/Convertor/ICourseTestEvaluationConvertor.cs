using Core.Base.Convertor;
using EduServices.CourseTestEvaluation.Dto;
using Model.Tables.Edu.CourseTestEvaluation;

namespace EduServices.CourseTestEvaluation.Convertor
{
    public interface ICourseTestEvaluationConvertor
        : IBaseConvertor<CourseTestEvaluationDbo, CourseTestEvaluationCreateDto, CourseTestEvaluationListDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto> { }
}
