using Core.Base.Command.Restore;
using Model.Edu.StudentGroup;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupRestore.Command
{
    public class StudentGroupRestoreService : BaseRestoreCommand<StudentGroupDbo, IStudentGroupRepository>, IStudentGroupRestoreService
    {
        public StudentGroupRestoreService(IStudentGroupRepository repository)
            : base(repository) { }
    }
}
