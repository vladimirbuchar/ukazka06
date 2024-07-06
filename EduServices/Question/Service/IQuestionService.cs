using Core.Base.Service;
using EduServices.Question.Dto;
using Model.Edu.Question;

namespace EduServices.Question.Service
{
    public interface IQuestionService : IBaseService<QuestionDbo, QuestionCreateDto, QuestionListDto, QuestionDetailDto, QuestionUpdateDto, QuestionFileRepositoryDbo> { }
}
