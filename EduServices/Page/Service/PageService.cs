using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Model.CodeBook;
using Services.Page.Dto;

namespace Services.Page.Service
{
    public class PageService(ICodeBookRepository<LicenseDbo> repository)
        : BaseService<ICodeBookRepository<LicenseDbo>, LicenseDbo>(repository),
            IPageService
    {
        public List<PriceListDto> PriceList()
        {
            List<LicenseDbo> licences = _repository.GetEntities(false).Result;
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
