using CodebookService.AddressTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.AddressTypeDropDown.Command
{
    public interface IAddressTypeDropDownService : IBaseDropDownCommand<AddressTypeDbo, AddressTypeDropDownDto>
    {
    }
}