using Core.Base.Service;
using Services.Page.Dto;
using System.Collections.Generic;

namespace Services.Page.Service
{
    public interface IPageService : IBaseService
    {
        HashSet<PriceListDto> PriceList();
    }
}
