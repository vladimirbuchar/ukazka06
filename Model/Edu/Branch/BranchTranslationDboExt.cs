using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Branch
{
    public static class BranchTranslationDboExt
    {
        public static BranchTranslationDbo FindTranslation(this ICollection<BranchTranslationDbo> translations, List<string> cultures)
        {
            BranchTranslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture?.SystemIdentificator == culture);
                if (translation != null)
                {
                    return translation;
                }
            }
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<BranchTranslationDbo> PrepareTranslation(
            this ICollection<BranchTranslationDbo> translations,
            string descriprion,
            Guid cultureId
        )
        {
            EduDbContext dbContext = new();
            translations ??= [];
            BranchTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(new BranchTranslationDbo() { CultureId = cultureId, Description = descriprion });
            }
            else
            {
                translation.Description = descriprion;
            }
            return translations;
        }
    }
}
