using CodebookService.LicenseDropDown.Convertor;
using CodebookService.LicenseDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.LicenseDropDown.Command
{
    public class LicenseDropDownService : BaseDropDownCommand<LicenseDbo, ICodeBookRepository<LicenseDbo>, LicenseDropDownDto, ILicenseDropDownConvertor>, ILicenseDropDownService
    {
        public LicenseDropDownService(ICodeBookRepository<LicenseDbo> repository, ILicenseDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
