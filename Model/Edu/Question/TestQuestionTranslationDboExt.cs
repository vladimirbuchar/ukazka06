using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Question
{
    public static class TestQuestionTranslationDboExt
    {
        public static QuestionTranslationDbo FindTranslation(this ICollection<QuestionTranslationDbo> translations, List<string> cultures)
        {
            QuestionTranslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
                if (translation != null)
                {
                    break;
                }
            }
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<QuestionTranslationDbo> PrepareTranslation(
            this ICollection<QuestionTranslationDbo> translations,
            string question,
            Guid cultureId
        )
        {
            translations ??= [];
            QuestionTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(new QuestionTranslationDbo() { CultureId = cultureId, Question = question, });
            }
            else
            {
                translation.Question = question;
            }
            return translations;
        }
    }
}
