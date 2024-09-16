using Core.Base.Command.Delete;
using Model.Link;
using Repository.StudentInGroup;

namespace OrganizationService.StudentInGroup.StudentInGroupDelete.Command
{
    public class StudentInGroupDeleteService : BaseDeleteCommand<StudentInGroupDbo, IStudentInGroupRepository>, IStudentInGroupDeleteService
    {
        public StudentInGroupDeleteService(IStudentInGroupRepository repository)
            : base(repository) { }
    }
}
