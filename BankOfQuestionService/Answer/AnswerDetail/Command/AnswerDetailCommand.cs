using BankOfQuestionService.Answer.AnswerDetail.Convertor;
using BankOfQuestionService.Answer.AnswerDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.Answer;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerDetail.Command
{
    public class AnswerDetailCommand : BaseDetailCommand<AnswerDbo, IAnswerRepository, AnswerDetailDto, IAnswerDetailConvertor>, IAnswerDetailCommand
    {
        public AnswerDetailCommand(IAnswerRepository repository, IAnswerDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
