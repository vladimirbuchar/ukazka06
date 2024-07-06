using Core.Base.Convertor;
using EduServices.Question.Dto;
using Model.Edu.Question;

namespace EduServices.Question.Convertor
{
    public interface IQuestionConvertor : IBaseConvertor<QuestionDbo, QuestionCreateDto, QuestionListDto, QuestionDetailDto, QuestionUpdateDto> { }
}
