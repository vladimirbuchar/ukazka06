using CodebookService.CountryDetail.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.CountryDetail.Convertor
{
    public interface ICountryDetailConvertor : IBaseDetailConvertor<CountryDbo, CountryDetailDto>
    {
    }
}