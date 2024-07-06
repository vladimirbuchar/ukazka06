using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;

namespace Model.Edu.BankOfQuestions
{
    public static class BankOfQuestionsTranslationDboExt
    {
        public static BankOfQuestionsTranslationDbo FindTranslation(this ICollection<BankOfQuestionsTranslationDbo> translations, string culture)
        {
            BankOfQuestionsTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<BankOfQuestionsTranslationDbo> PrepareTranslation(
            this ICollection<BankOfQuestionsTranslationDbo> translations,
            string name,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            BankOfQuestionsTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new BankOfQuestionsTranslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Name = name });
            }
            else
            {
                translation.Name = name;
            }

            return translations;
        }
    }
}
