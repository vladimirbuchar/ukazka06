using Core.Base.Service;
using EduServices.BankOfQuestion.Dto;
using Model.Tables.Edu.BankOfQuestions;

namespace EduServices.BankOfQuestion.Service
{
    public interface IBankOfQuestionService : IBaseService<BankOfQuestionDbo, BankOfQuestionCreateDto, BankOfQuestionListDto, BankOfQuestionDetailDto, BankOfQuestionUpdateDto> { }
}
