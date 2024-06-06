using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using EduServices.Page.Dto;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Page.Service
{
    public class PageService(ICodeBookRepository<LicenseDbo> repository) : BaseService<ICodeBookRepository<LicenseDbo>, LicenseDbo>(repository), IPageService
    {
        public HashSet<PriceListDto> PriceList()
        {
            HashSet<LicenseDbo> licences = _repository.GetEntities(false);
            return licences
                .Select(x => new PriceListDto()
                {
                    Id = x.Id,
                    MounthPrice = x.MounthPrice,
                    Name = x.SystemIdentificator,
                    OneYearSale = x.OneYearSale
                })
                .ToHashSet();
        }
    }
}
