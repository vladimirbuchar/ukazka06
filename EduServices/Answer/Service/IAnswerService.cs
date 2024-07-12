using Core.Base.Service;
using Model.Edu.Answer;
using Services.Answer.Dto;
using Services.Answer.Filter;

namespace Services.Answer.Service
{
    public interface IAnswerService
        : IBaseService<AnswerDbo, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto, AnswerFileRepositoryDbo, AnswerFilter> { }
}
