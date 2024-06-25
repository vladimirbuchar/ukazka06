using Core.Base.Dto;

namespace EduServices.Page.Dto
{
    public class PriceListDto : ListDto
    {
        public double MounthPrice { get; set; }
        public double OneYearSale { get; set; }
        public string Name { get; set; }
    }
}
