using CodebookService.CourseLessonItemTemplateDropDown.Convertor;
using CodebookService.CourseLessonItemTemplateDropDown.Dto;
using Core.Base.Command.DropDown;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;

namespace CodebookService.CourseLessonItemTemplateDropDown.Command
{
    public class CourseLessonItemTemplateDropDownService : BaseDropDownCommand<CourseLessonItemTemplateDbo, ICodeBookRepository<CourseLessonItemTemplateDbo>, CourseLessonItemTemplateDropDownDto, ICourseLessonItemTemplateDropDownConvertor>, ICourseLessonItemTemplateDropDownService
    {
        public CourseLessonItemTemplateDropDownService(ICodeBookRepository<CourseLessonItemTemplateDbo> repository, ICourseLessonItemTemplateDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
