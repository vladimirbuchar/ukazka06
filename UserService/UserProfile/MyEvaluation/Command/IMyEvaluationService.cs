using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.StudentEvaluation;
using UserService.UserProfile.MyEvaluation.Dto;

namespace UserService.UserProfile.MyEvaluation.Command
{
    public interface IMyEvaluationService : IBaseListCommand<StudentEvaluationDbo, MyEvaluationListDto, RequestFilter> { }
}
