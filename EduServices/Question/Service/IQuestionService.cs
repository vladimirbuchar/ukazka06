using Core.Base.Service;
using Model.Edu.Question;
using Services.Question.Dto;
using Services.Question.Filter;

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
            QuestionFilter
        > { }
}
