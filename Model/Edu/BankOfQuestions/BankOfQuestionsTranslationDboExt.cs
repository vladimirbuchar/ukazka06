using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.BankOfQuestions
{
    public static class BankOfQuestionsTranslationDboExt
    {
        public static BankOfQuestionsTranslationDbo FindTranslation(this ICollection<BankOfQuestionsTranslationDbo> translations, List<string> cultures)
        {
            BankOfQuestionsTranslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
                if (translation != null) { return translation; }
            }
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<BankOfQuestionsTranslationDbo> PrepareTranslation(
            this ICollection<BankOfQuestionsTranslationDbo> translations,
            string name,
            Guid cultureId
        )
        {
            translations ??= [];
            BankOfQuestionsTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(new BankOfQuestionsTranslationDbo() { CultureId = cultureId, Name = name });
            }
            else
            {
                translation.Name = name;
            }

            return translations;
        }
    }
}
