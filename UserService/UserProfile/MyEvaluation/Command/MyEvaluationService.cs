using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.StudentEvaluation;
using Repository.StudentEvaluation;
using UserService.UserProfile.MyEvaluation.Convertor;
using UserService.UserProfile.MyEvaluation.Dto;

namespace UserService.UserProfile.MyEvaluation.Command
{
    public class MyEvaluationService
        : BaseListCommand<StudentEvaluationDbo, IStudentEvaluationRepository, MyEvaluationListDto, IMyEvaluationConvertor, RequestFilter>,
            IMyEvaluationService
    {
        public MyEvaluationService(IStudentEvaluationRepository repository, IMyEvaluationConvertor convertor)
            : base(repository, convertor) { }
    }
}
