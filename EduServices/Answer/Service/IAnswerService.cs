using Core.Base.Service;
using EduServices.Answer.Dto;
using Model.Edu.Answer;

namespace EduServices.Answer.Service
{
    public interface IAnswerService : IBaseService<AnswerDbo, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto, AnswerFileRepositoryDbo> { }
}
