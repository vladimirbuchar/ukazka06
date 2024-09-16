using CodebookService.CountryDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.CountryDropDown.Convertor
{
    public interface ICountryDropDownConvertor : IBaseDropDownConvertor<CountryDbo, CountryDropDownDto>
    {
    }
}