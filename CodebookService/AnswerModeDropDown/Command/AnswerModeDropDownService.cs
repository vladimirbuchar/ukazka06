using CodebookService.AnswerModeDropDown.Convertor;
using CodebookService.AnswerModeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.AnswerModeDropDown.Command
{
    public class AnswerModeDropDownService : BaseDropDownCommand<AnswerModeDbo, ICodeBookRepository<AnswerModeDbo>, AnswerModeDropDownDto, IAnswerModeDropDownConvertor>, IAnswerModeDropDownService
    {
        public AnswerModeDropDownService(ICodeBookRepository<AnswerModeDbo> repository, IAnswerModeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
