using System.Collections.Generic;
using System.Linq;
using Model.Tables.CodeBook;

namespace Model.Tables.Edu.Organization
{
    public static class OrganizationTranslationDboExt
    {
        public static OrganizationTranslationDbo FindTranslation(this ICollection<OrganizationTranslationDbo> translations, string culture)
        {
            OrganizationTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<OrganizationTranslationDbo> PrepareTranslation(
            this ICollection<OrganizationTranslationDbo> translations,
            string description,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            OrganizationTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new OrganizationTranslationDbo() { Culture = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture), Description = description });
            }
            else
            {
                translation.Description = description;
            }
            return translations;
        }
    }
}
