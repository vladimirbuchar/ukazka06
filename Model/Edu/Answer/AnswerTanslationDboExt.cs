using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Answer
{
    public static class AnswerTanslationDboExt
    {
        public static AnswerTanslationDbo FindTranslation(
            this ICollection<AnswerTanslationDbo> translations,
            List<string> cultures,
            bool findSpecificCulture = false
        )
        {
            AnswerTanslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture?.SystemIdentificator == culture);
            }
            if (!findSpecificCulture)
            {
                translation ??= translations.FirstOrDefault();
            }
            return translation;
        }

        public static ICollection<AnswerTanslationDbo> PrepareTranslation(
            this ICollection<AnswerTanslationDbo> translations,
            string answer,
            Guid cultureId
        )
        {
            translations ??= [];
            AnswerTanslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(new AnswerTanslationDbo() { CultureId = cultureId, Answer = answer });
            }
            else
            {
                translation.Answer = answer;
            }
            return translations;
        }
    }
}
