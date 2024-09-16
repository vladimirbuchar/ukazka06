using Model.Edu.StudentEvaluation;
using UserService.UserProfile.MyEvaluation.Dto;

namespace UserService.UserProfile.MyEvaluation.Convertor
{
    public class MyEvaluationConvertor : IMyEvaluationConvertor
    {
        public Task<List<MyEvaluationListDto>> ConvertToWebModel(List<StudentEvaluationDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new MyEvaluationListDto() { }).ToList());
        }
    }
}
