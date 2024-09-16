using Core.Base.Command.Delete;
using Model.Edu.StudentGroup;
using Repository.StudentGroup;

namespace OrganizationService.StudentGroup.StudentGroupDelete.Command
{
    public class StudentGroupDeleteService : BaseDeleteCommand<StudentGroupDbo, IStudentGroupRepository>, IStudentGroupDeleteService
    {
        public StudentGroupDeleteService(IStudentGroupRepository repository)
            : base(repository) { }
    }
}
