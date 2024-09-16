using Core.Base.Command.Detail;
using CourseStudyService.CourseStudy.GetUserCourseItem.Dto;
using Model.Link;

namespace CourseStudyService.CourseStudy.GetUserCourseItem.Command
{
    public interface IGetUserCourseItemCommand : IBaseDetailCommand<CourseStudentMaterialDbo, GetUserCourseItemDto>
    {
    }
}