using System;
using System.Collections.Generic;
using Model.Edu.StudentEvaluation;
using Services.StudentEvaluation.Dto;

namespace Services.StudentEvaluation.Convertor
{
    public class StudentEvaluationConvertor : IStudentEvaluationConvertor
    {
        public StudentEvaluationDbo ConvertToBussinessEntity(StudentEvaluationCreateDto create, string culture)
        {
            return new StudentEvaluationDbo()
            {
                Evaluation = create.Evaluation,
                CourseStudentId = create.CourseStudentId,
                CourseTermId = create.CourseTermId
            };
        }

        public List<StudentEvaluationListDto> ConvertToWebModel(List<StudentEvaluationDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public StudentEvaluationDetailDto ConvertToWebModel(StudentEvaluationDbo detail, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
