using Core.Base.Command.Update;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Command
{
    public interface IStudentGroupUpdateService : IBaseUpdateCommand<StudentGroupDbo, StudentGroupUpdateDto> { }
}
