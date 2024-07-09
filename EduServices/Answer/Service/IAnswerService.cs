using Core.Base.Request;
using Core.Base.Service;
using Model.Edu.Answer;
using Services.Answer.Dto;

namespace Services.Answer.Service
{
    public interface IAnswerService
        : IBaseService<AnswerDbo, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto, AnswerFileRepositoryDbo, FilterRequest> { }
}
