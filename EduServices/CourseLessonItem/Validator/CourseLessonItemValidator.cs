using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItemRepository;
using Repository.CourseLessonRepository;
using Services.CourseLessonItem.Dto;
using System;
using System.Threading.Tasks;

namespace Services.CourseLessonItem.Validator
{
    public class CourseLessonItemValidator(
        ICourseLessonRepository courseLessonRepository,
        ICourseLessonItemRepository repository,
        ICodeBookRepository<CourseLessonItemTemplateDbo> codeBookRepository
    )
        : BaseValidator<
            CourseLessonItemDbo,
            ICourseLessonItemRepository,
            CourseLessonItemCreateDto,
            CourseLessonItemDetailDto,
            CourseLessonItemUpdateDto
        >(repository),
            ICourseLessonItemValidator
    {
        private readonly ICodeBookRepository<CourseLessonItemTemplateDbo> _courseLessonItemTemplates = codeBookRepository;
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;

        public override async Task<Result> IsValid(CourseLessonItemCreateDto create)
        {
            Result<CourseLessonItemDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_LESSON_ITEM, MessageItem.STRING_IS_EMPTY);
            await IsValidItemTemplate(create.TemplateId, result);
            if (await _courseLessonRepository.GetEntity(create.CourseLessonId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_LESSON, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        private async Task IsValidItemTemplate(Guid templateId, Result result)
        {
            if ((await _courseLessonItemTemplates.GetEntity(false, x => x.Id == templateId)).SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_LESSON_ITEM, Constants.COURSE_LESSON_ITEM_TEMPLATE_IS_EMPTY)
                );
            }
        }

        public override async Task<Result<CourseLessonItemDetailDto>> IsValid(CourseLessonItemUpdateDto update)
        {
            Result<CourseLessonItemDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_LESSON_ITEM, MessageItem.STRING_IS_EMPTY);
            await IsValidItemTemplate(update.TemplateId, result);
            return await Task.FromResult(result);
        }
    }
}
