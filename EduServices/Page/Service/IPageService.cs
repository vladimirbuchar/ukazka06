using System.Collections.Generic;
using Core.Base.Service;
using EduServices.Page.Dto;

namespace EduServices.Page.Service
{
    public interface IPageService : IBaseService
    {
        HashSet<PriceListDto> PriceList();
    }
}
