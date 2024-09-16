using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.CourseLessonItem
{
    public static class CourseLessonItemTranslationDboExt
    {
        public static CourseLessonItemTranslationDbo FindTranslation(this ICollection<CourseLessonItemTranslationDbo> translations, List<string> cultures)
        {
            CourseLessonItemTranslationDbo translation = null;
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

        public static ICollection<CourseLessonItemTranslationDbo> PrepareTranslation(
            this ICollection<CourseLessonItemTranslationDbo> translations,
            string name,
            string html,
            Guid cultureId
        )
        {
            translations ??= [];
            CourseLessonItemTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new CourseLessonItemTranslationDbo()
                    {
                        CultureId = cultureId,
                        Name = name,
                        Html = html,
                    }
                );
            }
            else
            {
                translation.Name = name;
                translation.Html = html;
            }
            return translations;
        }
    }
}
