using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Convertor;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.BankOfQuestions;
using Repository.BankOfQuestion;

namespace BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Command
{
    public class BankOfQuestionDetailService
        : BaseDetailCommand<BankOfQuestionDbo, IBankOfQuestionRepository, BankOfQuestionDetailDto, IBankOfQuestionDetailConvertor>,
            IBankOfQuestionDetailService
    {
        public BankOfQuestionDetailService(IBankOfQuestionRepository repository, IBankOfQuestionDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
