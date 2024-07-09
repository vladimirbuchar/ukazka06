using Core.Base.Convertor;
using Model.Edu.CourseTestEvaluation;
using Services.CourseTestEvaluation.Dto;

namespace Services.CourseTestEvaluation.Convertor
{
    public interface ICourseTestEvaluationConvertor
        : IBaseConvertor<
            CourseTestEvaluationDbo,
            CourseTestEvaluationCreateDto,
            CourseTestEvaluationListDto,
            CourseTestEvaluationDetailDto,
            CourseTestEvaluationUpdateDto
        > { }
}
