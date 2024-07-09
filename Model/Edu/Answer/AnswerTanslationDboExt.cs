using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;

namespace Model.Edu.Answer
{
    public static class AnswerTanslationDboExt
    {
        public static AnswerTanslationDbo FindTranslation(
            this ICollection<AnswerTanslationDbo> translations,
            string culture,
            bool findSpecificCulture = false
        )
        {
            AnswerTanslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture?.SystemIdentificator == culture);
            if (!findSpecificCulture)
            {
                translation ??= translations.FirstOrDefault();
            }
            return translation;
        }

        public static ICollection<AnswerTanslationDbo> PrepareTranslation(
            this ICollection<AnswerTanslationDbo> translations,
            string answer,
            string culture,
            List<CultureDbo> cultureList
        )
        {
            translations ??= [];
            AnswerTanslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new AnswerTanslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Answer = answer }
                );
            }
            else
            {
                translation.Answer = answer;
            }
            return translations;
        }
    }
}
