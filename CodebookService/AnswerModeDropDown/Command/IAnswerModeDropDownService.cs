using CodebookService.AnswerModeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.AnswerModeDropDown.Command
{
    public interface IAnswerModeDropDownService : IBaseDropDownCommand<AnswerModeDbo, AnswerModeDropDownDto>
    {
    }
}