using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Course
{
    public static class CourseTranslationDboExt
    {
        public static CourseTranslationDbo FindTranslation(this ICollection<CourseTranslationDbo> translations, List<string> cultures)
        {
            CourseTranslationDbo translation = null;
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

        public static ICollection<CourseTranslationDbo> PrepareTranslation(
            this ICollection<CourseTranslationDbo> translations,
            string name,
            string description,
            Guid cultureId
        )
        {
            translations ??= [];
            CourseTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new CourseTranslationDbo()
                    {
                        CultureId = cultureId,
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
