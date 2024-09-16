using Core.Base.Command.Detail;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDetail.Dto;

namespace OrganizationService.StudentGroup.StudentGroupDetail.Command
{
    public interface IStudentGroupDetailService : IBaseDetailCommand<StudentGroupDbo, StudentGroupDetailDto> { }
}
