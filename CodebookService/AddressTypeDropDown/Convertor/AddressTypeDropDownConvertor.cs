using CodebookService.AddressTypeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.AddressTypeDropDown.Convertor
{
    public class AddressTypeDropDownConvertor : IAddressTypeDropDownConvertor
    {
        public Task<List<AddressTypeDropDownDto>> ConvertToWebModel(List<AddressTypeDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new AddressTypeDropDownDto()
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
