using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using Core.Base.Convertor;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerUpdate.Convertor
{
    public interface IAnswerUpdateConvertor : IBaseUpdateConvertor<AnswerDbo, AnswerUpdateDto> { }
}
