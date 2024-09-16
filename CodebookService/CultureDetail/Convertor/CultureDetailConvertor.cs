using CodebookService.CultureDetail.Dto;
using Model.CodeBook;

namespace CodebookService.CultureDetail.Convertor
{
    public class CultureDetailConvertor : ICultureDetailConvertor
    {
        public Task<CultureDetailDto> ConvertToWebModel(CultureDbo detail, List<string> culture)
        {
            return Task.FromResult(new CultureDetailDto()
            {
                Id = detail.Id,
            });
        }
    }
}
