using System.Collections.Generic;
using System.Linq;
using Model.CodeBook;

namespace Model.Edu.Message
{
    public static class MessageTranslationDboExt
    {
        public static MessageTranslationDbo FindTranslation(this ICollection<MessageTranslationDbo> translations, string culture)
        {
            MessageTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<MessageTranslationDbo> PrepareTranslation(
            this ICollection<MessageTranslationDbo> translations,
            string subject,
            string html,
            string culture,
            List<CultureDbo> cultureList
        )
        {
            translations ??= [];
            MessageTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new MessageTranslationDbo()
                    {
                        CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id,
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
