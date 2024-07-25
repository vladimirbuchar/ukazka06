using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseLessonItem.Convertor
{
    public class CourseLessonItemConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : ICourseLessonItemConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<CourseLessonItemDbo> ConvertToBussinessEntity(CourseLessonItemCreateDto addCourseLessonItemDto, string culture)
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
            return Task.FromResult(courseLessonItem);
        }

        public Task<List<CourseLessonItemListDto>> ConvertToWebModel(List<CourseLessonItemDbo> getCourseLessonItems, string culture)
        {
            return Task.FromResult(getCourseLessonItems
                .Select(item => new CourseLessonItemListDto()
                {
                    Name = item.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                    //Html = item.CourseLessonItemTranslations.FindTranslation(culture)?.Html,
                    Id = item.Id,
                    Position = item.Position,
                })
                .ToList());
        }

        public Task<CourseLessonItemDetailDto> ConvertToWebModel(CourseLessonItemDbo getCourseLessonItemDetail, string culture)
        {
            return Task.FromResult(new CourseLessonItemDetailDto()
            {
                Name = getCourseLessonItemDetail.CourseLessonItemTranslations.FindTranslation(culture)?.Name,
                Id = getCourseLessonItemDetail.Id,
                Html = getCourseLessonItemDetail.CourseLessonItemTranslations.FindTranslation(culture)?.Html,
                CourseLessonItemTemplateId = getCourseLessonItemDetail.CourseLessonItemTemplateId,
                TemplateIdentificator = getCourseLessonItemDetail.CourseLessonItemTemplate.SystemIdentificator,
                Youtube = getCourseLessonItemDetail.Youtube
            });
        }

        public Task<CourseLessonItemDbo> ConvertToBussinessEntity(
            CourseLessonItemUpdateDto updateCourseLessonItemDto,
            CourseLessonItemDbo entity,
            string culture
        )
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
            return Task.FromResult(entity);
        }
    }
}
