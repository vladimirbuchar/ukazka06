using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Model.CodeBook;
using Services.Page.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Page.Service
{
    public class PageService(ICodeBookRepository<LicenseDbo> repository)
        : BaseService<ICodeBookRepository<LicenseDbo>, LicenseDbo>(repository),
            IPageService
    {
        public async Task<List<PriceListDto>> PriceList()
        {
            List<LicenseDbo> licences = await _repository.GetEntities(false, null, null,
            [
                new Core.Base.Sort.BaseSort<LicenseDbo>()
                {
                    Sort = x=>x.Priority,
                    SortDirection  = System.Web.Helpers.SortDirection.Ascending
                }
            ]);
            return licences
                .Select(x => new PriceListDto()
                {
                    Id = x.Id,
                    MounthPrice = x.MounthPrice,
                    Name = x.SystemIdentificator,
                    OneYearSale = x.OneYearSale
                })
                .ToList();
        }
    }
}
