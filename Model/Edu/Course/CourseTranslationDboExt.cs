using Model.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Course
{
    public static class CourseTranslationDboExt
    {
        public static CourseTranslationDbo FindTranslation(this ICollection<CourseTranslationDbo> translations, string culture)
        {
            CourseTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<CourseTranslationDbo> PrepareTranslation(
            this ICollection<CourseTranslationDbo> translations,
            string name,
            string description,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            CourseTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new CourseTranslationDbo()
                    {
                        CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id,
                        Name = name,
                        Description = description
                    }
                );
            }
            else
            {
                translation.Name = name;
                translation.Description = description;
            }

            return translations;
        }
    }
}
