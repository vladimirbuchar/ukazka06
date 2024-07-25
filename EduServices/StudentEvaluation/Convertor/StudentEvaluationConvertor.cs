using Model.Edu.StudentEvaluation;
using Services.StudentEvaluation.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.StudentEvaluation.Convertor
{
    public class StudentEvaluationConvertor : IStudentEvaluationConvertor
    {
        public Task<StudentEvaluationDbo> ConvertToBussinessEntity(StudentEvaluationCreateDto create, string culture)
        {
            return Task.FromResult(new StudentEvaluationDbo()
            {
                Evaluation = create.Evaluation,
                CourseStudentId = create.CourseStudentId,
                CourseTermId = create.CourseTermId
            });
        }

        public Task<List<StudentEvaluationListDto>> ConvertToWebModel(List<StudentEvaluationDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public Task<StudentEvaluationDetailDto> ConvertToWebModel(StudentEvaluationDbo detail, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
