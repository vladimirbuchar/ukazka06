using EduServices.StudentEvaluation.Dto;
using Model.Edu.StudentEvaluation;
using System;
using System.Collections.Generic;

namespace EduServices.StudentEvaluation.Convertor
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



        public HashSet<StudentEvaluationListDto> ConvertToWebModel(HashSet<StudentEvaluationDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public StudentEvaluationDetailDto ConvertToWebModel(StudentEvaluationDbo detail, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
