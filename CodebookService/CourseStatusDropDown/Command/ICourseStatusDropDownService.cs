using CodebookService.CourseStatusDropDown.Dto;
using Core.Base.Command.DropDown;
using Model.CodeBook;

namespace CodebookService.CourseStatusDropDown.Command
{
    public interface ICourseStatusDropDownService : IBaseDropDownCommand<CourseStatusDbo, CourseStatusDropDownDto>
    {
    }
}