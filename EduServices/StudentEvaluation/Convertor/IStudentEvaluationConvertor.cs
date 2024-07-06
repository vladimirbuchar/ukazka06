using Core.Base.Convertor;
using EduServices.StudentEvaluation.Dto;
using Model.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Convertor
{
    public interface IStudentEvaluationConvertor : IBaseConvertor<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {

    }
}
