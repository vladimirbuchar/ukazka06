using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupList.Dto;

namespace OrganizationService.StudentGroup.StudentGroupList.Convertor
{
    public class StudentGroupListConvertor : IStudentGroupListConvertor
    {
        public Task<List<StudentGroupListDto>> ConvertToWebModel(List<StudentGroupDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentGroupListDto() { Id = x.Id, Name = x.Name, }).ToList());
        }
    }
}
