using System.Collections.Generic;
using System.Linq;
using Model.Tables.CodeBook;

namespace Model.Tables.Edu.Branch
{
    public static class BranchTranslationDboExt
    {
        public static BranchTranslationDbo FindTranslation(this ICollection<BranchTranslationDbo> translations, string culture)
        {
            BranchTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture?.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<BranchTranslationDbo> PrepareTranslation(
            this ICollection<BranchTranslationDbo> translations,
            string name,
            string descriprion,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            BranchTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new BranchTranslationDbo()
                    {
                        CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id,
                        Name = name,
                        Description = descriprion
                    }
                );
            }
            else
            {
                translation.Name = name;
                translation.Description = descriprion;
            }

            return translations;
        }
    }
}
