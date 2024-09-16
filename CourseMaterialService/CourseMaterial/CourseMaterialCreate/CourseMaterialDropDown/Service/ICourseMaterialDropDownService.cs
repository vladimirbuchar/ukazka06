using Core.Base.Command.DropDown;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Service
{
    public interface ICourseMaterialDropDownService : IBaseDropDownCommand<CourseMaterialDbo, CourseMaterialDropDownDto>
    {
    }
}