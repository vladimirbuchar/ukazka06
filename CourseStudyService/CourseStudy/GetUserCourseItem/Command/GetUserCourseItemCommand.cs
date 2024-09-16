using Core.Base.Command.Detail;
using CourseStudyService.CourseStudy.GetUserCourseItem.Dto;
using Model.Link;
using Repository.CouseStudentMaterial;
using System.Linq.Expressions;

namespace CourseStudyService.CourseStudy.GetUserCourseItem.Command
{
    public class GetUserCourseItemCommand : BaseDetailCommand<CourseStudentMaterialDbo, ICourseStudentMaterialRepository, GetUserCourseItemDto>, IGetUserCourseItemCommand
    {
        public GetUserCourseItemCommand(ICourseStudentMaterialRepository repository) : base(repository)
        {
        }
        public override async Task<GetUserCourseItemDto?> Execute(Expression<Func<CourseStudentMaterialDbo, bool>> predicate, List<string> culture, Dictionary<string, object>? replace = null)
        {
            CourseStudentMaterialDbo item = await _repository.GetEntity(false, predicate);
            return item == null
                ? null
                : new GetUserCourseItemDto() { CourseLessonItem = item.CourseLessonItemId, ItemType = item.CourseLessonItem.CourseLesson.Type };
        }
    }
}
