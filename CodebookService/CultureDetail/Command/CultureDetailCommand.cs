using CodebookService.CultureDetail.Convertor;
using CodebookService.CultureDetail.Dto;
using Core.Base.Command.Detail;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CultureDetail.Command
{
    public class CultureDetailCommand : BaseDetailCommand<CultureDbo, ICodeBookRepository<CultureDbo>, CultureDetailDto, ICultureDetailConvertor>, ICultureDetailCommand
    {
        public CultureDetailCommand(ICodeBookRepository<CultureDbo> repository, ICultureDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
