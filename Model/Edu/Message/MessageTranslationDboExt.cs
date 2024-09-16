using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Message
{
    public static class MessageTranslationDboExt
    {
        public static MessageTemplateTranslationDbo FindTranslation(this ICollection<MessageTemplateTranslationDbo> translations, List<string> cultures)
        {
            MessageTemplateTranslationDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
                if (translation != null)
                {
                    return translation;
                }
            }
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<MessageTemplateTranslationDbo> PrepareTranslation(
            this ICollection<MessageTemplateTranslationDbo> translations,
            string subject,
            string html,
            Guid cultureId
        )
        {
            translations ??= [];
            MessageTemplateTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new MessageTemplateTranslationDbo()
                    {
                        CultureId = cultureId,
                        Subject = subject,
                        Html = html,
                    }
                );
            }
            else
            {
                translation.Subject = subject;
                translation.Html = html;
            }
            return translations;
        }
    }
}
