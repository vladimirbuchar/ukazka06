using CodebookService.CountryDetail.Dto;
using Core.Base.Command.Detail;
using Model.CodeBook;

namespace CodebookService.CountryDetail.Command
{
    public interface ICountryDetailCommand : IBaseDetailCommand<CountryDbo, CountryDetailDto>
    {
    }
}