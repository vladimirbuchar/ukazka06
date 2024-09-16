using Core.Base.Command.DropDown;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Dto;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.CourseMaterialDropDown.Service
{
    public class CourseMaterialDropDownService : BaseDropDownCommand<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialDropDownDto, ICourseMaterialDropDownConvertor>, ICourseMaterialDropDownService
    {
        public CourseMaterialDropDownService(ICourseMaterialRepository repository, ICourseMaterialDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
