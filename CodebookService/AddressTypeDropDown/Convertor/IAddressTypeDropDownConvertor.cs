using CodebookService.AddressTypeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.AddressTypeDropDown.Convertor
{
    public interface IAddressTypeDropDownConvertor : IBaseDropDownConvertor<AddressTypeDbo, AddressTypeDropDownDto>
    {
    }
}