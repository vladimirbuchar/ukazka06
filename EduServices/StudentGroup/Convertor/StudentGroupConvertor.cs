using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.StudentGroup;
using Services.StudentGroup.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.StudentGroup.Convertor
{
    public class StudentGroupConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IStudentGroupConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<List<StudentGroupInOrganizationListDto>> ConvertToWebModel(List<StudentGroupDbo> getStudentGroupInOrganizations, string culture)
        {
            return Task.FromResult(getStudentGroupInOrganizations
                .Select(x => new StudentGroupInOrganizationListDto() { Id = x.Id, Name = x.StudentGroupTranslations.FindTranslation(culture)?.Name, })
                .ToList());
        }

        public Task<StudentGroupDetailDto> ConvertToWebModel(StudentGroupDbo getStudentGroupDetail, string culture)
        {
            return Task.FromResult(new StudentGroupDetailDto()
            {
                Id = getStudentGroupDetail.Id,
                Name = getStudentGroupDetail.StudentGroupTranslations.FindTranslation(culture)?.Name
            });
        }

        public Task<StudentGroupDbo> ConvertToBussinessEntity(StudentGroupCreateDto addStudentGroupDto, string culture)
        {
            StudentGroupDbo studentgroup = new() { OrganizationId = addStudentGroupDto.OrganizationId };
            studentgroup.StudentGroupTranslations = studentgroup.StudentGroupTranslations.PrepareTranslation(
                addStudentGroupDto.Name,
                culture,
                _cultureList
            );
            return Task.FromResult(studentgroup);
        }

        public Task<StudentGroupDbo> ConvertToBussinessEntity(StudentGroupUpdateDto updateStudentGroupDto, StudentGroupDbo entity, string culture)
        {
            entity.StudentGroupTranslations = entity.StudentGroupTranslations.PrepareTranslation(updateStudentGroupDto.Name, culture, _cultureList);
            return Task.FromResult(entity);
        }
    }
}
