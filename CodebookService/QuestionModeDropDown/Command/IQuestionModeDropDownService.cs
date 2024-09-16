using CodebookService.QuestionModeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.QuestionModeDropDown.Command
{
    public interface IQuestionModeDropDownService : IBaseDropDownCommand<QuestionModeDbo, QuestionModeDropDownDto>
    {
    }
}