using Core.Base.Service;
using Model.Edu.StudentGroup;
using Services.StudentGroup.Dto;

namespace Services.StudentGroup.Service
{
    public interface IStudentGroupService : IBaseService<StudentGroupDbo, StudentGroupCreateDto, StudentGroupInOrganizationListDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
