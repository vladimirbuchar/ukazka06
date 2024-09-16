using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Convertor
{
    public class StudentGroupCreateConvertor : IStudentGroupCreateConvertor
    {
        public Task<StudentGroupDbo> ConvertToBussinessEntity(StudentGroupCreateDto create, string culture)
        {
            StudentGroupDbo studentgroup = new() { OrganizationId = create.OrganizationId, Name = create.Name };
            return Task.FromResult(studentgroup);
        }
    }
}
