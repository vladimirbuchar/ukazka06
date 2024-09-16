using CourseStudyService.StudentEvaluation.StudentEvaluationList.Dto;
using Model.Edu.StudentEvaluation;

namespace CourseStudyService.StudentEvaluation.StudentEvaluationList.Convertor
{
    public class StudentEvaluationListConvertor : IStudentEvaluationListConvertor
    {
        public Task<List<StudentEvaluationListDto>> ConvertToWebModel(List<StudentEvaluationDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentEvaluationListDto()
            {
                Date = x.Date,
                Evaluation = x.Evaluation,
                FirstName = x.CourseStudent.UserInOrganization.User.Person.FirstName,
                Id = x.Id,
                LastName = x.CourseStudent.UserInOrganization.User.Person.LastName,
                SecondName = x.CourseStudent.UserInOrganization.User.Person.SecondName,
                UserEmail = x.CourseStudent.UserInOrganization.User.UserEmail,
                StudentId = x.CourseStudentId
            }).ToList());
        }
    }
}
