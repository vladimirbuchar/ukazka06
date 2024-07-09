using Core.Base.Service;
using Model.Edu.StudentGroup;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Filter;

namespace Services.StudentGroup.Service
{
    public interface IStudentGroupService
        : IBaseService<
            StudentGroupDbo,
            StudentGroupCreateDto,
            StudentGroupInOrganizationListDto,
            StudentGroupDetailDto,
            StudentGroupUpdateDto,
            StudentGroupFilter
        > { }
}
