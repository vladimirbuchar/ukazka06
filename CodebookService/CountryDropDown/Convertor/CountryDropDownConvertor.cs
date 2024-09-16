using CodebookService.CountryDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.CountryDropDown.Convertor
{
    public class CountryDropDownConvertor : ICountryDropDownConvertor
    {
        public Task<List<CountryDropDownDto>> ConvertToWebModel(List<CountryDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new CountryDropDownDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Name,
                SystemIdentificator = item.SystemIdentificator
            })
             .ToList());
        }
    }
}
