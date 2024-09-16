using CodebookService.TimeTableDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.TimeTableDropDown.Command
{
    public interface ITimeTableDropDownService : IBaseDropDownCommand<TimeTableDbo, TimeTableDropDownDto>
    {
    }
}