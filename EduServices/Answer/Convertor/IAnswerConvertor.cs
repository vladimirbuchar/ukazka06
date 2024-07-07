using Core.Base.Convertor;
using Model.Edu.Answer;
using Services.Answer.Dto;

namespace Services.Answer.Convertor
{
    public interface IAnswerConvertor : IBaseConvertor<AnswerDbo, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto> { }
}
