using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupCreate.Convertor;
using OrganizationService.StudentGroup.StudentGroupCreate.Dto;
using OrganizationService.StudentGroup.StudentGroupCreate.Validator;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupCreate.Command
{
    public class StudentGroupCreateService(
        IStudentGroupRepository repository,
        IStudentGroupCreateConvertor convertor,
        IStudentGroupCreateValidator validator,
        ICodeBookRepository<CultureDbo> culture
        )
                : BaseCreateCommand<
            StudentGroupDbo,
            IStudentGroupRepository,
            StudentGroupCreateDto,
            IStudentGroupCreateConvertor,
            IStudentGroupCreateValidator

        >(repository, convertor, validator, culture),
            IStudentGroupCreateService
    {
    }
}
