using Core.Base.Convertor;
using Model.Edu.BankOfQuestions;
using Services.BankOfQuestion.Dto;

namespace Services.BankOfQuestion.Convertor
{
    public interface IBankOfQuestionConvertor : IBaseConvertor<BankOfQuestionDbo, BankOfQuestionCreateDto, BankOfQuestionListDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto> { }
}
