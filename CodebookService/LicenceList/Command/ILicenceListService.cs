using CodebookService.LicenceList.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Model.CodeBook;

namespace CodebookService.LicenceList.Command
{
    public interface ILicenceListService : IBaseListCommand<LicenseDbo, LicenceListDto, RequestFilter> { }
}
