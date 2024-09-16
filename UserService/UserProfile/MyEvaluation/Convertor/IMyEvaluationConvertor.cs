using Core.Base.Convertor;
using Model.Edu.StudentEvaluation;
using UserService.UserProfile.MyEvaluation.Dto;

namespace UserService.UserProfile.MyEvaluation.Convertor
{
    public interface IMyEvaluationConvertor : IBaseListConvertor<StudentEvaluationDbo, MyEvaluationListDto> { }
}
