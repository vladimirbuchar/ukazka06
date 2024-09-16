using CodebookService.QuestionModeDropDown.Convertor;
using CodebookService.QuestionModeDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.QuestionModeDropDown.Command
{
    public class QuestionModeDropDownService : BaseDropDownCommand<QuestionModeDbo, ICodeBookRepository<QuestionModeDbo>, QuestionModeDropDownDto, IQuestionModeDropDownConvertor>, IQuestionModeDropDownService
    {
        public QuestionModeDropDownService(ICodeBookRepository<QuestionModeDbo> repository, IQuestionModeDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
