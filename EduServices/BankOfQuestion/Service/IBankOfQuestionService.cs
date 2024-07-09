using Core.Base.Request;
using Core.Base.Service;
using Model.Edu.BankOfQuestions;
using Services.BankOfQuestion.Dto;

namespace Services.BankOfQuestion.Service
{
    public interface IBankOfQuestionService
        : IBaseService<
            BankOfQuestionDbo,
            BankOfQuestionCreateDto,
            BankOfQuestionListDto,
            BankOfQuestionDetailDto,
            BankOfQuestionUpdateDto,
            FilterRequest
        > { }
}
