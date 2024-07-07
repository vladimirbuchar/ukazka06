using Core.Base.Validator;
using Model.Edu.Question;
using Repository.QuestionRepository;
using Services.Question.Dto;

namespace Services.Question.Validator
{
    public interface IQuestionValidator : IBaseValidator<QuestionDbo, IQuestionRepository, QuestionCreateDto, QuestionDetailDto, QuestionUpdateDto> { }
}
