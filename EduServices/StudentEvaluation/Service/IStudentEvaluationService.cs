using Core.Base.Service;
using Model.Edu.StudentEvaluation;
using Services.StudentEvaluation.Dto;

namespace Services.StudentEvaluation.Service
{
    public interface IStudentEvaluationService : IBaseService<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {

    }
}
