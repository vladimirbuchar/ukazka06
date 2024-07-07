using System.Collections.Generic;
using Core.Base.Service;
using Services.Page.Dto;

namespace Services.Page.Service
{
    public interface IPageService : IBaseService
    {
        HashSet<PriceListDto> PriceList();
    }
}
