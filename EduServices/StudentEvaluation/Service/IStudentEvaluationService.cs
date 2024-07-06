using Core.Base.Service;
using EduServices.StudentEvaluation.Dto;
using Model.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Service
{
    public interface IStudentEvaluationService : IBaseService<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {

    }
}
