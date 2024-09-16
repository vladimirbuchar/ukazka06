using CodebookService.AddressTypeDropDown.Convertor;
using CodebookService.AddressTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.AddressTypeDropDown.Command
{
    public class AddressTypeDropDownService(ICodeBookRepository<AddressTypeDbo> repository, IAddressTypeDropDownConvertor convertor) : BaseDropDownCommand<AddressTypeDbo, ICodeBookRepository<AddressTypeDbo>, AddressTypeDropDownDto, IAddressTypeDropDownConvertor>(repository, convertor), IAddressTypeDropDownService
    {
    }
}
