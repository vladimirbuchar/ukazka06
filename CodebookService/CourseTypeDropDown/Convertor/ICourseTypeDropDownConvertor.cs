using CodebookService.CourseTypeDropDown.Dto;
using Core.Base.Convertor;
using Model.CodeBook;

namespace CodebookService.CourseTypeDropDown.Convertor
{
    public interface ICourseTypeDropDownConvertor : IBaseDropDownConvertor<CourseTypeDbo, CourseTypeDropDownDto>
    {
    }
}