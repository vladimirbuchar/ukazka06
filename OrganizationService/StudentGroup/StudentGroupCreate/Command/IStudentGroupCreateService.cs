using Core.Base.Command.Create;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Command
{
    public interface IStudentGroupCreateService : IBaseCreateCommand<StudentGroupDbo, StudentGroupCreateDto> { }
}
