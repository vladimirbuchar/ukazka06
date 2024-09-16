using CodebookService.CourseTypeDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.CourseTypeDropDown.Command
{
    public interface ICourseTypeDropDownService : IBaseDropDownCommand<CourseTypeDbo, CourseTypeDropDownDto>
    {
    }
}