using Core.Base.Service;
using Model.Edu.StudentGroup;
using Repository.StudentGroupRepository;
using Services.StudentGroup.Convertor;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Validator;

namespace Services.StudentGroup.Service
{
    public class StudentGroupService(IStudentGroupValidator validator, IStudentGroupRepository studentGroupRepository, IStudentGroupConvertor studentGroupConvertor)
        : BaseService<
            IStudentGroupRepository,
            StudentGroupDbo,
            IStudentGroupConvertor,
            IStudentGroupValidator,
            StudentGroupCreateDto,
            StudentGroupInOrganizationListDto,
            StudentGroupDetailDto,
            StudentGroupUpdateDto
        >(studentGroupRepository, studentGroupConvertor, validator),
            IStudentGroupService { }
}
