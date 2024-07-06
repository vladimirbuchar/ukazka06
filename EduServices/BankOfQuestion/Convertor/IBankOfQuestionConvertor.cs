using Core.Base.Convertor;
using EduServices.BankOfQuestion.Dto;
using Model.Edu.BankOfQuestions;

namespace EduServices.BankOfQuestion.Convertor
{
    public interface IBankOfQuestionConvertor : IBaseConvertor<BankOfQuestionDbo, BankOfQuestionCreateDto, BankOfQuestionListDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto> { }
}
