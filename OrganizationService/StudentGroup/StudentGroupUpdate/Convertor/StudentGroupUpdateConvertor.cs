using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Convertor
{
    public class StudentGroupUpdateConvertor : IStudentGroupUpdateConvertor
    {
        public Task<StudentGroupDbo> ConvertToBussinessEntity(StudentGroupUpdateDto update, StudentGroupDbo entity, string culture)
        {
            entity.Name = update.Name;
            return Task.FromResult(entity);
        }
    }
}
