using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;

namespace Services.CourseLesson.Convertor
{
    public class CourseLessonConvertor(ICodeBookRepository<CultureDbo> codeBookService) : ICourseLessonConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

        public CourseLessonDbo ConvertToBussinessEntity(CourseLessonCreateDto addCourseLessonDto, string culture)
        {
            CourseLessonDbo courseLesson =
                new()
                {
                    Type = addCourseLessonDto.Type,
                    //PowerPointFile = addCourseLessonDto.PowerPointFile,
                    CourseMaterialId = addCourseLessonDto.MaterialId
                };
            courseLesson.CourseLessonTranslations = courseLesson.CourseLessonTranslations.PrepareTranslation(addCourseLessonDto.Name, culture, _cultureList);
            return courseLesson;
        }

        public CourseLessonDbo ConvertToBussinessEntity(CourseLessonUpdateDto update, CourseLessonDbo entity, string culture)
        {
            entity.CourseLessonTranslations = entity.CourseLessonTranslations.PrepareTranslation(update.Name, culture, _cultureList);
            return entity;
        }

        public HashSet<CourseLessonListDto> ConvertToWebModel(HashSet<CourseLessonDbo> getAllLessonInCourses, string culture)
        {
            return getAllLessonInCourses
                .Select(item => new CourseLessonListDto()
                {
                    Name = item.CourseLessonTranslations.FindTranslation(culture).Name,
                    Id = item.Id,
                    Type = item.Type,
                    Position = item.Position,
                })
                .ToHashSet();
        }

        public CourseLessonDetailDto ConvertToWebModel(CourseLessonDbo getCourseLessonDetail, string culture)
        {
            return new CourseLessonDetailDto()
            {
                Name = getCourseLessonDetail.CourseLessonTranslations.FindTranslation(culture).Name,
                Id = getCourseLessonDetail.Id,
                Type = getCourseLessonDetail.Type
            };
        }
    }
}
