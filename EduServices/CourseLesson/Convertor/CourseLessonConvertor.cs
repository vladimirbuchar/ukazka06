using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.CourseLesson.Convertor
{
    public class CourseLessonConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : ICourseLessonConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<CourseLessonDbo> ConvertToBussinessEntity(CourseLessonCreateDto addCourseLessonDto, string culture)
        {
            CourseLessonDbo courseLesson =
                new()
                {
                    Type = addCourseLessonDto.Type,
                    //PowerPointFile = addCourseLessonDto.PowerPointFile,
                    CourseMaterialId = addCourseLessonDto.MaterialId
                };
            courseLesson.CourseLessonTranslations = courseLesson.CourseLessonTranslations.PrepareTranslation(
                addCourseLessonDto.Name,
                culture,
                _cultureList
            );
            return Task.FromResult(courseLesson);
        }

        public Task<CourseLessonDbo> ConvertToBussinessEntity(CourseLessonUpdateDto update, CourseLessonDbo entity, string culture)
        {
            entity.CourseLessonTranslations = entity.CourseLessonTranslations.PrepareTranslation(update.Name, culture, _cultureList);
            return Task.FromResult(entity);
        }

        public Task<List<CourseLessonListDto>> ConvertToWebModel(List<CourseLessonDbo> getAllLessonInCourses, string culture)
        {
            return Task.FromResult(getAllLessonInCourses
                .Select(item => new CourseLessonListDto()
                {
                    Name = item.CourseLessonTranslations.FindTranslation(culture).Name,
                    Id = item.Id,
                    Type = item.Type,
                    Position = item.Position,
                })
                .ToList());
        }

        public Task<CourseLessonDetailDto> ConvertToWebModel(CourseLessonDbo getCourseLessonDetail, string culture)
        {
            return Task.FromResult(new CourseLessonDetailDto()
            {
                Name = getCourseLessonDetail.CourseLessonTranslations.FindTranslation(culture).Name,
                Id = getCourseLessonDetail.Id,
                Type = getCourseLessonDetail.Type
            });
        }
    }
}
