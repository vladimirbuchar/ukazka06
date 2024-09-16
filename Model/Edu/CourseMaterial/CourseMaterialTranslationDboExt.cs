using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.CourseMaterial
{
    public static class CourseMaterialTranslationDboExt
    {
        public static CourseMaterialTranslationDbo FindTranslation(this ICollection<CourseMaterialTranslationDbo> translations, List<string> cultures)
        {
            CourseMaterialTranslationDbo translation = null;
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

        public static ICollection<CourseMaterialTranslationDbo> PrepareTranslation(
            this ICollection<CourseMaterialTranslationDbo> translations,
            string name,
            string description,
            Guid cultureId
        )
        {
            translations ??= [];
            CourseMaterialTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new CourseMaterialTranslationDbo()
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
