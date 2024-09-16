using Core.Base.Command.Detail;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDetail.Convertor;
using OrganizationService.StudentGroup.StudentGroupDetail.Dto;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupDetail.Command
{
    public class StudentGroupDetailService
        : BaseDetailCommand<StudentGroupDbo, IStudentGroupRepository, StudentGroupDetailDto, IStudentGroupDetailConvertor>,
            IStudentGroupDetailService
    {
        public StudentGroupDetailService(IStudentGroupRepository repository, IStudentGroupDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
