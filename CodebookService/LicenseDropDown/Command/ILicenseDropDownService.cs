using CodebookService.LicenseDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.LicenseDropDown.Command
{
    public interface ILicenseDropDownService : IBaseDropDownCommand<LicenseDbo, LicenseDropDownDto>
    {
    }
}