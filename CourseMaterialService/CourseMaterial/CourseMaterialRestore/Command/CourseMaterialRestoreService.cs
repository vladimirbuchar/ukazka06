using Core.Base.Command.Restore;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialRestore.Command
{
    public class CourseMaterialRestoreService : BaseRestoreCommand<CourseMaterialDbo, ICourseMaterialRepository>, ICourseMaterialRestoreService
    {
        public CourseMaterialRestoreService(ICourseMaterialRepository repository)
            : base(repository) { }
    }
}
