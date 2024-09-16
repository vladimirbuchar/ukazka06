using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDetail.Dto;

namespace OrganizationService.StudentGroup.StudentGroupDetail.Convertor
{
    public class StudentGroupDetailConvertor : IStudentGroupDetailConvertor
    {
        public Task<StudentGroupDetailDto> ConvertToWebModel(StudentGroupDbo detail, List<string> culture)
        {
            return Task.FromResult(new StudentGroupDetailDto() { Id = detail.Id, Name = detail.Name });
        }
    }
}
