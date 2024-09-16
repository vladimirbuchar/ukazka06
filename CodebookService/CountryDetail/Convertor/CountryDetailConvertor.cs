using CodebookService.CountryDetail.Dto;
using Model.CodeBook;

namespace CodebookService.CountryDetail.Convertor
{
    public class CountryDetailConvertor : ICountryDetailConvertor
    {
        public Task<CountryDetailDto> ConvertToWebModel(CountryDbo detail, List<string> culture)
        {
            return Task.FromResult(new CountryDetailDto()
            {
                Id = detail.Id,
                Name = detail.Name
            });
        }
    }
}
