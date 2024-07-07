using Model.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.CourseLessonItem
{
    public static class CourseLessonItemTranslationDboExt
    {
        public static CourseLessonItemTranslationDbo FindTranslation(this ICollection<CourseLessonItemTranslationDbo> translations, string culture)
        {
            CourseLessonItemTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<CourseLessonItemTranslationDbo> PrepareTranslation(
            this ICollection<CourseLessonItemTranslationDbo> translations,
            string name,
            string html,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            CourseLessonItemTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new CourseLessonItemTranslationDbo()
                    {
                        CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id,
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
