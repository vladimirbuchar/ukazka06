using Core.Base.Command.DropDown;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDropDown.Dto;

namespace OrganizationService.StudentGroup.StudentGroupDropDown.Service
{
    public interface IStudentGroupDropDownService : IBaseDropDownCommand<StudentGroupDbo, StudentGroupDropDownDto>
    {
    }
}