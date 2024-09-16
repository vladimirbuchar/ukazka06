using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.CourseLesson
{
    public static class CourseLessonTranslationDboExt
    {
        public static CourseLessonTranslationDbo FindTranslation(this ICollection<CourseLessonTranslationDbo> translations, List<string> cultures)
        {
            CourseLessonTranslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
                if (translation != null)
                {
                    return translation;
                }
            }

            translation ??= translations.FirstOrDefault();

            return translation;
        }

        public static ICollection<CourseLessonTranslationDbo> PrepareTranslation(
            this ICollection<CourseLessonTranslationDbo> translations,
            string name,
            Guid cultureId
        )
        {
            translations ??= [];
            CourseLessonTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(new CourseLessonTranslationDbo() { CultureId = cultureId, Name = name });
            }
            else
            {
                translation.Name = name;
            }
            return translations;
        }
    }
}
