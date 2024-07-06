using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;

namespace Model.Edu.CourseLesson
{
    public static class CourseLessonTranslationDboExt
    {
        public static CourseLessonTranslationDbo FindTranslation(this ICollection<CourseLessonTranslationDbo> translations, string culture)
        {
            CourseLessonTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<CourseLessonTranslationDbo> PrepareTranslation(
            this ICollection<CourseLessonTranslationDbo> translations,
            string name,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            CourseLessonTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new CourseLessonTranslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Name = name });
            }
            else
            {
                translation.Name = name;
            }
            return translations;
        }
    }
}
