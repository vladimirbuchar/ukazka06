using Core.Base.Service;
using EduServices.Question.Dto;
using Model.Tables.Edu.TestQuestion;

namespace EduServices.Question.Service
{
    public interface IQuestionService : IBaseService<QuestionDbo, QuestionCreateDto, QuestionListDto, QuestionDetailDto, QuestionUpdateDto, QuestionFileRepositoryDbo> { }
}
