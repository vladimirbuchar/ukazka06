using Core.Base.Command.Detail;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Dto;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialDetail.Command
{
    public class CourseMaterialDetailService
        : BaseDetailCommand<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialDetailDto, ICourseMaterialDetailConvertor>,
            ICourseMaterialDetailService
    {
        public CourseMaterialDetailService(ICourseMaterialRepository repository, ICourseMaterialDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
