using Core.Base.Repository.CodeBookRepository;
using EduServices.CourseLessonItem.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.CourseLessonItem;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseLessonItem.Convertor
{
    public class CourseLessonItemConvertor(ICodeBookRepository<CultureDbo> codeBookService) : ICourseLessonItemConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetCodeBookItems();

        public CourseLessonItemDbo ConvertToBussinessEntity(CourseLessonItemCreateDto addCourseLessonItemDto, string culture)
        {
            CourseLessonItemDbo courseLessonItem =
                new()
                {
                    CourseLessonId = addCourseLessonItemDto.CourseLessonId,
                    CourseLessonItemTemplateId = addCourseLessonItemDto.TemplateId,
                    Youtube = addCourseLessonItemDto.Youtube
                };
            courseLessonItem.CourseLessonItemTranslations = courseLessonItem.CourseLessonItemTranslations.PrepareTranslation(
                addCourseLessonItemDto.Name,
                addCourseLessonItemDto.Html,
                culture,
                _cultureList
            );
            return courseLessonItem;
        }

        public HashSet<CourseLessonItemListDto> ConvertToWebModel(HashSet<CourseLessonItemDbo> getCourseLessonItems, string culture)
        {
            return getCourseLessonItems
                .Select(item => new CourseLessonItemListDto()
                {
                    Name = item.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                    //Html = item.CourseLessonItemTranslations.FindTranslation(culture)?.Html,
                    Id = item.Id,
                    Position = item.Position,
                })
                .ToHashSet();
        }

        public CourseLessonItemDetailDto ConvertToWebModel(CourseLessonItemDbo getCourseLessonItemDetail, string culture)
        {
            return new CourseLessonItemDetailDto()
            {
                Name = getCourseLessonItemDetail.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                Id = getCourseLessonItemDetail.Id,
                Html = getCourseLessonItemDetail.CourseLessonItemTranslations.FindTranslation(culture)?.Html,
                CourseLessonItemTemplateId = getCourseLessonItemDetail.CourseLessonItemTemplateId,
                TemplateIdentificator = getCourseLessonItemDetail.CourseLessonItemTemplate.SystemIdentificator,

                Youtube = getCourseLessonItemDetail.Youtube
            };
        }

        public CourseLessonItemDbo ConvertToBussinessEntity(CourseLessonItemUpdateDto updateCourseLessonItemDto, CourseLessonItemDbo entity, string culture)
        {
            entity.Youtube = updateCourseLessonItemDto.Youtube;
            entity.CourseLessonItemTemplateId = updateCourseLessonItemDto.TemplateId;
            entity.CourseLessonItemTemplate = null;
            entity.CourseLessonItemTranslations = entity.CourseLessonItemTranslations.PrepareTranslation(
                updateCourseLessonItemDto.Name,
                updateCourseLessonItemDto.Html,
                culture,
                _cultureList
            );
            return entity;
        }
    }
}
