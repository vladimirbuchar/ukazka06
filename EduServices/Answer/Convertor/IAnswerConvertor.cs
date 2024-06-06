using Core.Base.Convertor;
using EduServices.Answer.Dto;
using Model.Tables.Edu.Answer;

namespace EduServices.Answer.Convertor
{
    public interface IAnswerConvertor : IBaseConvertor<AnswerDbo, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto> { }
}
