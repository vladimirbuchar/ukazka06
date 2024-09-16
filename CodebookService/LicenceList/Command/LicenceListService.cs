using CodebookService.LicenceList.Convertor;
using CodebookService.LicenceList.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.LicenceList.Command
{
    public class LicenceListService
        : BaseListCommand<LicenseDbo, ICodeBookRepository<LicenseDbo>, LicenceListDto, ILicenceListConvertor, RequestFilter>,
            ILicenceListService
    {
        public LicenceListService(ICodeBookRepository<LicenseDbo> repository, ILicenceListConvertor convertor)
            : base(repository, convertor) { }
    }
}
