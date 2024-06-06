using Core.Base.Repository.CodeBookRepository;
using EduServices.CourseLesson.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.CourseLesson;
using Model.Tables.Edu.CourseLessonItem;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseLesson.Convertor
{
    public class CourseLessonConvertor(ICodeBookRepository<CultureDbo> codeBookService) : ICourseLessonConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetCodeBookItems();

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
