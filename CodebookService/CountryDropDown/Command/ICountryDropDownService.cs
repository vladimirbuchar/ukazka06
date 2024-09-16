using CodebookService.CountryDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.CountryDropDown.Command
{
    public interface ICountryDropDownService : IBaseDropDownCommand<CountryDbo, CountryDropDownDto>
    {
    }
}