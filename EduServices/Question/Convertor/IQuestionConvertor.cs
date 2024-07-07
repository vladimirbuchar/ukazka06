using Core.Base.Convertor;
using Model.Edu.Question;
using Services.Question.Dto;

namespace Services.Question.Convertor
{
    public interface IQuestionConvertor : IBaseConvertor<QuestionDbo, QuestionCreateDto, QuestionListDto, QuestionDetailDto, QuestionUpdateDto> { }
}
