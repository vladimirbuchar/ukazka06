using Core.Base.Validator;
using Model.Edu.Answer;
using Repository.AnswerRepository;
using Services.Answer.Dto;

namespace Services.Answer.Validator
{
    public interface IAnswerValidator : IBaseValidator<AnswerDbo, IAnswerRepository, AnswerCreateDto, AnswerDetailDto, AnswerUpdateDto> { }
}
