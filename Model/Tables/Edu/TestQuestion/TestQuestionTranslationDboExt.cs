﻿using System.Collections.Generic;
using System.Linq;
using Model.Tables.CodeBook;

namespace Model.Tables.Edu.TestQuestion
{
    public static class TestQuestionTranslationDboExt
    {
        public static QuestionTranslationDbo FindTranslation(this ICollection<QuestionTranslationDbo> translations, string culture)
        {
            QuestionTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<QuestionTranslationDbo> PrepareTranslation(this ICollection<QuestionTranslationDbo> translations, string question, string culture, HashSet<CultureDbo> cultureList)
        {
            translations ??= [];
            QuestionTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new QuestionTranslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Question = question, });
            }
            else
            {
                translation.Question = question;
            }
            return translations;
        }
    }
}
