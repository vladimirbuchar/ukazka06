using CodebookService.NoteTypeDropDown.Dto;
using Model.CodeBook;

namespace CodebookService.NoteTypeDropDown.Convertor
{
    public class NoteTypeDropDownConvertor : INoteTypeDropDownConvertor
    {
        public Task<List<NoteTypeDropDownDto>> ConvertToWebModel(List<NoteTypeDbo> list, List<string> culture)
        {
            return Task.FromResult(list
             .Select(item => new NoteTypeDropDownDto()
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
