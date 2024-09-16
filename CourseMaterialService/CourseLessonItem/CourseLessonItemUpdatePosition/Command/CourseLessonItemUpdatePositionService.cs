using Core.Base.Command.Update;
using Core.DataTypes;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Dto;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdatePosition.Command
{
    public class CourseLessonItemUpdatePositionService
        : BaseUpdateCommand<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemUpdatePositionDto>,
            ICourseLessonItemUpdatePositionService
    {
        public CourseLessonItemUpdatePositionService(ICourseLessonItemRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(CourseLessonItemUpdatePositionDto update, Guid userId, string culture, Result? result = null)
        {
            int position = 0;
            foreach (string item in update.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonItemDbo courseLessonItemDbo = await _repository.GetEntity(id);
                if (courseLessonItemDbo != null)
                {
                    courseLessonItemDbo.Position = position;
                    _ = await _repository.UpdateEntity(courseLessonItemDbo, userId);
                }
                position++;
            }
            return new Result();
        }
    }
}
