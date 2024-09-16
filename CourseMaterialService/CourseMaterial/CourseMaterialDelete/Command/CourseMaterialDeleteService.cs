using Core.Base.Command.Delete;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialDelete.Command
{
    public class CourseMaterialDeleteService : BaseDeleteCommand<CourseMaterialDbo, ICourseMaterialRepository>, ICourseMaterialDeleteService
    {
        public CourseMaterialDeleteService(ICourseMaterialRepository repository)
            : base(repository) { }
    }
}
