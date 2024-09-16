using Core.Base.Convertor;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupList.Dto;

namespace OrganizationService.StudentGroup.StudentGroupList.Convertor
{
    public interface IStudentGroupListConvertor : IBaseListConvertor<StudentGroupDbo, StudentGroupListDto> { }
}
