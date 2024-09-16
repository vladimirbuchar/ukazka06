using CodebookService.CourseStatusDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.CourseStatusDropDown.Convertor
{
    public interface ICourseStatusDropDownConvertor : IBaseDropDownConvertor<CourseStatusDbo, CourseStatusDropDownDto>
    {
    }
}