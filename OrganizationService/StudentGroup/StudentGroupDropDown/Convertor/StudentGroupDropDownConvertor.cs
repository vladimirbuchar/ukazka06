using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupDropDown.Dto;

namespace OrganizationService.StudentGroup.StudentGroupDropDown.Convertor
{
    public class StudentGroupDropDownConvertor : IStudentGroupDropDownConvertor
    {
        public Task<List<StudentGroupDropDownDto>> ConvertToWebModel(List<StudentGroupDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentGroupDropDownDto()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }
    }
}
