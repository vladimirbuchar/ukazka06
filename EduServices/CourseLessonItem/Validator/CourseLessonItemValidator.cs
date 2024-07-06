using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseLessonItemRepository;
using EduRepository.CourseLessonRepository;
using EduServices.CourseLessonItem.Dto;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseLessonItem.Validator
{
    public class CourseLessonItemValidator(ICourseLessonRepository courseLessonRepository, ICourseLessonItemRepository repository, ICodeBookRepository<CourseLessonItemTemplateDbo> codeBookRepository)
        : BaseValidator<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemCreateDto, CourseLessonItemDetailDto, CourseLessonItemUpdateDto>(repository),
            ICourseLessonItemValidator
    {
        private readonly HashSet<CourseLessonItemTemplateDbo> _courseLessonItemTemplates = codeBookRepository.GetEntities(false);
        private readonly ICourseLessonRepository _courseLessonRepository = courseLessonRepository;

        public override Result<CourseLessonItemDetailDto> IsValid(CourseLessonItemCreateDto create)
        {
            Result<CourseLessonItemDetailDto> result = new();
            IsValidString(create.Name, result, Category.COURSE_LESSON_ITEM, GlobalValue.STRING_IS_EMPTY);
            IsValidItemTemplate(create.TemplateId, result);
            if (_courseLessonRepository.GetEntity(create.CourseLessonId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_LESSON, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        private void IsValidItemTemplate(Guid templateId, Result result)
        {
            if (_courseLessonItemTemplates.FirstOrDefault(x => x.Id == templateId).SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_LESSON_ITEM, Constants.COURSE_LESSON_ITEM_TEMPLATE_IS_EMPTY));
            }
        }

        public override Result<CourseLessonItemDetailDto> IsValid(CourseLessonItemUpdateDto update)
        {
            Result<CourseLessonItemDetailDto> result = new();
            IsValidString(update.Name, result, Category.COURSE_LESSON_ITEM, GlobalValue.STRING_IS_EMPTY);
            IsValidItemTemplate(update.TemplateId, result);
            return result;
        }
    }
}
