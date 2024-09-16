using CodebookService.CultureDropDown.Dto;
using Core.Constants;
using Model.CodeBook;

namespace CodebookService.CultureDropDown.Convertor
{
    public class CultureDropDownConvertor : ICultureDropDownConvertor
    {
        public Task<List<CultureDropDownDto>> ConvertToWebModel(List<CultureDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(item => new CultureDropDownDto()
            {
                Id = item.Id,
                IsDefault = item.IsDefault,
                Name = item.Value == CodebookValue.CODEBOOK_SELECT_VALUE
                                            ? string.Format("{0}", item.Value)
                                            : string.Format("{0} ({1})", item.Value, item.Name),
                SystemIdentificator = item.SystemIdentificator,
                Priority = item.Priority
            })
               .ToList());
        }
    }
}
