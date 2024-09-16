using CodebookService.EmailTypeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.EmailTypeDropDown.Convertor
{
    public class EmailTypeDropDownConvertor : IEmailTypeDropDownConvertor
    {
        public Task<List<EmailDetailServiceDto>> ConvertToWebModel(List<EmailTypeDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new EmailDetailServiceDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Name,
                SystemIdentificator = item.SystemIdentificator
            })
             .ToList());
        }
    }
}
