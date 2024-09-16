using Core.Base.Command.Create;
using Core.DataTypes;
using CourseStudyService.CourseStudy.SaveActiveSlide.Dto;
using Model.Link;
using Repository.CouseStudentMaterial;

namespace CourseStudyService.CourseStudy.SaveActiveSlide.Command
{
    public class SaveActiveSlideCommand : BaseCreateCommand<CourseStudentMaterialDbo, ICourseStudentMaterialRepository, SaveActiveSlideDto>, ISaveActiveSlideCommand
    {
        public SaveActiveSlideCommand(ICourseStudentMaterialRepository repository) : base(repository)
        {
        }
        public override async Task<ResultInsert> Execute(SaveActiveSlideDto addObject, Guid userId, string culture)
        {
            CourseStudentMaterialDbo entity = await _repository.GetEntity(false, x => x.UserId == userId && x.CourseId == addObject.CourseId);
            if (entity == null)
            {
                _ = await _repository.CreateEntity(
                    new CourseStudentMaterialDbo()
                    {
                        UserId = userId,
                        CourseLessonItemId = addObject.SlideId,
                        CourseId = addObject.CourseId
                    },
                    userId
                );
            }
            else
            {

                entity.CourseLessonItemId = addObject.SlideId;
                _ = await _repository.UpdateEntity(entity, userId);
            }
            return new ResultInsert();
        }
    }
}
