using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;

namespace Model.Edu.CourseMaterial
{
    public static class CourseMaterialTranslationDboExt
    {
        public static CourseMaterialTranslationDbo FindTranslation(this ICollection<CourseMaterialTranslationDbo> translations, string culture)
        {
            CourseMaterialTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<CourseMaterialTranslationDbo> PrepareTranslation(
            this ICollection<CourseMaterialTranslationDbo> translations,
            string name,
            string description,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            CourseMaterialTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new CourseMaterialTranslationDbo()
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
