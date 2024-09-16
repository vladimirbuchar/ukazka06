using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseLessonItem.CourseLessonItemDetail.Dto;
using CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Dto;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemUpdate.Validator
{
    public class CourseLessonItemUpdateValidator
        : BaseUpdateValidator<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemUpdateDto>,
            ICourseLessonItemUpdateValidator
    {
        private readonly ICodeBookRepository<CourseLessonItemTemplateDbo> _courseLessonItemTemplates;

        public CourseLessonItemUpdateValidator(
            ICourseLessonItemRepository repository,
            ICodeBookRepository<CourseLessonItemTemplateDbo> courseLessonItemTemplates
        )
            : base(repository)
        {
            _courseLessonItemTemplates = courseLessonItemTemplates;
        }

        private async Task IsValidItemTemplate(Guid templateId, Result result)
        {
            if (
                (await _courseLessonItemTemplates.GetEntity(false, x => x.Id == templateId)).SystemIdentificator
                == CodebookValue.CODEBOOK_SELECT_VALUE
            )
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_LESSON_ITEM, Constants.COURSE_LESSON_ITEM_TEMPLATE_IS_EMPTY)
                );
            }
        }

        public override async Task<Result> IsValid(CourseLessonItemUpdateDto update)
        {
            Result<CourseLessonItemDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_LESSON_ITEM, MessageItem.STRING_IS_EMPTY);
            await IsValidItemTemplate(update.TemplateId, result);
            return await Task.FromResult(result);
        }
    }
}
