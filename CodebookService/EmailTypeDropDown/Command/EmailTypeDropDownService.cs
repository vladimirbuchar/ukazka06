using CodebookService.EmailTypeDropDown.Convertor;
using CodebookService.EmailTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.EmailTypeDropDown.Command
{
    public class EmailTypeDropDownService : BaseDropDownCommand<EmailTypeDbo, ICodeBookRepository<EmailTypeDbo>, EmailDetailServiceDto, IEmailTypeDropDownConvertor>, IEmailTypeDropDownService
    {
        public EmailTypeDropDownService(ICodeBookRepository<EmailTypeDbo> repository, IEmailTypeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
