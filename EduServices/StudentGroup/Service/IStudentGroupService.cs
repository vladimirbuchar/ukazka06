using Core.Base.Service;
using EduServices.StudentGroup.Dto;
using Model.Tables.Edu.StudentGroup;

namespace EduServices.StudentGroup.Service
{
    public interface IStudentGroupService : IBaseService<StudentGroupDbo, StudentGroupCreateDto, StudentGroupInOrganizationListDto, StudentGroupDetailDto, StudentGroupUpdateDto> { }
}
