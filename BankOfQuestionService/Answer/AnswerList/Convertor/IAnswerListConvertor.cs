using BankOfQuestionService.Answer.AnswerList.Dto;
using Core.Base.Convertor;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerList.Convertor
{
    public interface IAnswerListConvertor : IBaseListConvertor<AnswerDbo, AnswerListDto> { }
}
