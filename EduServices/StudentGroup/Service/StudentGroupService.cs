using Core.Base.Service;
using EduRepository.StudentGroupRepository;
using EduServices.StudentGroup.Convertor;
using EduServices.StudentGroup.Dto;
using EduServices.StudentGroup.Validator;
using Model.Edu.StudentGroup;

namespace EduServices.StudentGroup.Service
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
