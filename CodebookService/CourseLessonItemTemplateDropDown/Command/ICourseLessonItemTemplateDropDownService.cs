using CodebookService.CourseLessonItemTemplateDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.CourseLessonItemTemplateDropDown.Command
{
    public interface ICourseLessonItemTemplateDropDownService : IBaseDropDownCommand<CourseLessonItemTemplateDbo, CourseLessonItemTemplateDropDownDto>
    {
    }
}