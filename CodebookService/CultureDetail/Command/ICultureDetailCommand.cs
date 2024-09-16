using CodebookService.CultureDetail.Dto;
using Core.Base.Command.Detail;
using Model.CodeBook;

namespace CodebookService.CultureDetail.Command
{
    public interface ICultureDetailCommand : IBaseDetailCommand<CultureDbo, CultureDetailDto>
    {
    }
}