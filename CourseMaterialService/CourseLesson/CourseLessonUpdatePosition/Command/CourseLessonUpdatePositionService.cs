using Core.Base.Command.Update;
using Core.DataTypes;
using CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Dto;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdatePosition.Command
{
    public class CourseLessonUpdatePositionService
        : BaseUpdateCommand<CourseLessonDbo, ICourseLessonRepository, CourseLessonUpdatePositionDto>,
            ICourseLessonUpdatePositionService
    {
        public CourseLessonUpdatePositionService(ICourseLessonRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(CourseLessonUpdatePositionDto update, Guid userId, string culture, Result? result = null)
        {
            int position = 0;
            foreach (string item in update.Ids)
            {
                Guid id = Guid.Parse(item);
                CourseLessonDbo entity = await _repository.GetEntity(id);
                if (entity != null)
                {
                    entity.Position = position;
                    _ = await _repository.UpdateEntity(entity, userId);
                    position++;
                }
            }
            return new Result();
        }
    }
}
