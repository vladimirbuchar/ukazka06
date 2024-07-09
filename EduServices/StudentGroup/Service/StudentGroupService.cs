using System.Collections.Generic;
using System.Linq;
using Core.Base.Service;
using Model.Edu.StudentGroup;
using Repository.StudentGroupRepository;
using Services.StudentGroup.Convertor;
using Services.StudentGroup.Dto;
using Services.StudentGroup.Filter;
using Services.StudentGroup.Validator;

namespace Services.StudentGroup.Service
{
    public class StudentGroupService(
        IStudentGroupValidator validator,
        IStudentGroupRepository studentGroupRepository,
        IStudentGroupConvertor studentGroupConvertor
    )
        : BaseService<
            IStudentGroupRepository,
            StudentGroupDbo,
            IStudentGroupConvertor,
            IStudentGroupValidator,
            StudentGroupCreateDto,
            StudentGroupInOrganizationListDto,
            StudentGroupDetailDto,
            StudentGroupUpdateDto,
            StudentGroupFilter
        >(studentGroupRepository, studentGroupConvertor, validator),
            IStudentGroupService
    {
        protected override List<StudentGroupDbo> PrepareMemoryFilter(List<StudentGroupDbo> entities, StudentGroupFilter filter, string culture)
        {
            if (!string.IsNullOrEmpty(filter.Name))
            {
                entities = entities
                    .Where(x => x.StudentGroupTranslations.Any(y => y.Name.Contains(filter.Name) && y.Culture.SystemIdentificator == culture))
                    .ToList();
            }
            return entities;
        }
    }
}
