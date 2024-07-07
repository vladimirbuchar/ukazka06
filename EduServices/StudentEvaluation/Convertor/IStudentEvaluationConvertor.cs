using Core.Base.Convertor;
using Model.Edu.StudentEvaluation;
using Services.StudentEvaluation.Dto;

namespace Services.StudentEvaluation.Convertor
{
    public interface IStudentEvaluationConvertor : IBaseConvertor<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {

    }
}
