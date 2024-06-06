using Core.Base.Service;
using EduServices.CourseTestEvaluation.Dto;
using Model.Tables.Edu.CourseTestEvaluation;

namespace EduServices.CourseTestEvaluation.Service
{
    public interface ICourseTestEvaluationService
        : IBaseService<CourseTestEvaluationDbo, CourseTestEvaluationCreateDto, CourseTestEvaluationListDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto> { }
}
