using Core.Base.Service;
using Model.Edu.CourseTestEvaluation;
using Services.CourseTestEvaluation.Dto;

namespace Services.CourseTestEvaluation.Service
{
    public interface ICourseTestEvaluationService
        : IBaseService<CourseTestEvaluationDbo, CourseTestEvaluationCreateDto, CourseTestEvaluationListDto, CourseTestEvaluationDetailDto, CourseTestEvaluationUpdateDto>
    { }
}
