using Core.Base.Dto;

namespace CodebookService.LicenceList.Dto
{
    public class LicenceListDto : ListDto
    {
        public double MounthPrice { get; set; }
        public double OneYearSale { get; set; }
        public string? Name { get; set; }
        public double OneYearPrice => Math.Round(MounthPrice * 12 / 100 * (100 - OneYearSale), 2);
        public double YouSave => Math.Round(12 * MounthPrice - OneYearPrice, 2);
    }
}
