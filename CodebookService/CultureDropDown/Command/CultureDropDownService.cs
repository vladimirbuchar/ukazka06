using CodebookService.CultureDropDown.Convertor;
using CodebookService.CultureDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CultureDropDown.Command
{
    public class CultureDropDownService : BaseDropDownCommand<CultureDbo, ICodeBookRepository<CultureDbo>, CultureDropDownDto, ICultureDropDownConvertor>, ICultureDropDownService
    {
        public CultureDropDownService(ICodeBookRepository<CultureDbo> repository, ICultureDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
