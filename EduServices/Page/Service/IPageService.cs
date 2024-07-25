using Core.Base.Service;
using Services.Page.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Page.Service
{
    public interface IPageService : IBaseService
    {
        Task<List<PriceListDto>> PriceList();
    }
}
