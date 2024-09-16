using BankOfQuestionService.Answer.AnswerCreate.Dto;
using Core.Base.Convertor;
using Model.Edu.Answer;

namespace BankOfQuestionService.Answer.AnswerCreate.Convertor
{
    public interface IAnswerCreateConvertor : IBaseCreateConvertor<AnswerDbo, AnswerCreateDto> { }
}
