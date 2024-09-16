using CodebookService.TimeTableDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.TimeTableDropDown.Convertor
{
    public interface ITimeTableDropDownConvertor : IBaseDropDownConvertor<TimeTableDbo, TimeTableDropDownDto>
    {
    }
}