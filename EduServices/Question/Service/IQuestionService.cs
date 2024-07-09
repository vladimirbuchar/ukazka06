using Core.Base.Request;
using Core.Base.Service;
using Model.Edu.Question;
using Services.Question.Dto;

namespace Services.Question.Service
{
    public interface IQuestionService
        : IBaseService<
            QuestionDbo,
            QuestionCreateDto,
            QuestionListDto,
            QuestionDetailDto,
            QuestionUpdateDto,
            QuestionFileRepositoryDbo,
            FilterRequest
        > { }
}
