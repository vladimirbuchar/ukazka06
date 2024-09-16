using CodebookService.LicenceList.Dto;
using Model.CodeBook;

namespace CodebookService.LicenceList.Convertor
{
    public class LicenceListConvertor : ILicenceListConvertor
    {
        public Task<List<LicenceListDto>> ConvertToWebModel(List<LicenseDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new LicenceListDto()
                {
                    Id = x.Id,
                    MounthPrice = x.MounthPrice,
                    Name = x.Name,
                    OneYearSale = x.OneYearSale,
                })
                    .ToList()
            );
        }
    }
}
