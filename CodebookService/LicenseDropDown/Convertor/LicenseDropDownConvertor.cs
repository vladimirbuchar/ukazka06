using CodebookService.LicenseDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.LicenseDropDown.Convertor
{
    public class LicenseDropDownConvertor : ILicenseDropDownConvertor
    {
        public Task<List<LicenseDropDownDto>> ConvertToWebModel(List<LicenseDbo> list, List<string> culture)
        {
            return Task.FromResult(list
             .Select(item => new LicenseDropDownDto()
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
