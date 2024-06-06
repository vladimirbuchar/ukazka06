using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.StudentEvaluation.Dto;
using Model.Tables.Edu.StudentEvaluation;

namespace EduServices.StudentEvaluation.Service
{
    public interface IStudentEvaluationService : IBaseService<StudentEvaluationDbo, StudentEvaluationCreateDto, StudentEvaluationListDto, StudentEvaluationDetailDto>
    {
        HashSet<MyEvaluationListDto> GetMyEvaluation(Guid userId);
    }
}
