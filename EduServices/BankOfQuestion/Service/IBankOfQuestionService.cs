using Core.Base.Service;
using Model.Edu.BankOfQuestions;
using Services.BankOfQuestion.Dto;
using Services.BankOfQuestion.Filter;

namespace Services.BankOfQuestion.Service
{
    public interface IBankOfQuestionService
        : IBaseService<
            BankOfQuestionDbo,
            BankOfQuestionCreateDto,
            BankOfQuestionListDto,
            BankOfQuestionDetailDto,
            BankOfQuestionUpdateDto,
            BankOfQuestionFilter
        > { }
}
