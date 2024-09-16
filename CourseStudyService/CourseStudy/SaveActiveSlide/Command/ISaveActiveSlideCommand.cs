using Core.Base.Command.Create;
using CourseStudyService.CourseStudy.SaveActiveSlide.Dto;
using Model.Link;

namespace CourseStudyService.CourseStudy.SaveActiveSlide.Command
{
    public interface ISaveActiveSlideCommand : IBaseCreateCommand<CourseStudentMaterialDbo, SaveActiveSlideDto>
    {
    }
}