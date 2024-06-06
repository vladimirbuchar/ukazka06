using Core.Base.Validator;
using EduRepository.QuestionRepository;
using EduServices.Question.Dto;
using Model.Tables.Edu.TestQuestion;

namespace EduServices.Question.Validator
{
    public interface IQuestionValidator : IBaseValidator<QuestionDbo, IQuestionRepository, QuestionCreateDto, QuestionDetailDto, QuestionUpdateDto> { }
}
