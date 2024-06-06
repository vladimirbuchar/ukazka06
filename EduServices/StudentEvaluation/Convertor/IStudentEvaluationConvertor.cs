using System.Collections.Generic;
using Core.Base.Convertor;
using EduServices.StudentEvaluation.Dto;
using Model.Tables.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Convertor
{
    public interface IStudentEvaluationConvertor : IBaseConvertor<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {
        HashSet<MyEvaluationListDto> ConvertToWebModel(HashSet<StudentEvaluationDbo> getStudentEvaluation);
    }
}
