using Core.Base.Command.Create;
using Model.Link;
using OrganizationService.StudentInGroup.StudentInGroupCreate.Dto;

namespace OrganizationService.StudentInGroup.StudentInGroupCreate.Command
{
    public interface IStudentInGroupCreateService : IBaseCreateCommand<StudentInGroupDbo, AddStudentToStudentGroup> { }
}
