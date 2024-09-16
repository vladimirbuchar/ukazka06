using CodebookService.QuestionModeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.QuestionModeDropDown.Convertor
{
    public interface IQuestionModeDropDownConvertor : IBaseDropDownConvertor<QuestionModeDbo, QuestionModeDropDownDto>
    {
    }
}