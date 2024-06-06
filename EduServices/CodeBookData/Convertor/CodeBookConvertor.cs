using EduServices.CodeBookData.Dto;
using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CodeBookData.Convertor
{
    public class CodeBookConvertor : ICodeBookConvertor
    {
        public HashSet<CodeBookItemListDto> ConvertToWebModel<T>(HashSet<T> codebookItems)
            where T : CodeBook
        {
            return codebookItems
                .Select(item => new CodeBookItemListDto()
                {
                    Id = item.Id,
                    IsDefault = item.IsDefault,
                    Name = item.Name,
                    SystemIdentificator = item.SystemIdentificator
                })
                .ToHashSet();
        }
    }
}
