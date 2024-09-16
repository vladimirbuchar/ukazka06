using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.StudentGroup;
using OrganizationService.StudentGroup.StudentGroupUpdate.Convertor;
using OrganizationService.StudentGroup.StudentGroupUpdate.Dto;
using OrganizationService.StudentGroup.StudentGroupUpdate.Validator;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupUpdate.Command
{
    public class StudentGroupUpdateService
        : BaseUpdateCommand<
            StudentGroupDbo,
            IStudentGroupRepository,
            StudentGroupUpdateDto,
            IStudentGroupUpdateConvertor,
            IStudentGroupUpdateValidator

        >,
            IStudentGroupUpdateService
    {
        public StudentGroupUpdateService(
            IStudentGroupRepository repository,
            IStudentGroupUpdateConvertor convertor,
            IStudentGroupUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
