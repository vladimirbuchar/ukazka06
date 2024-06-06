using System.Collections.Generic;
using System.Linq;
using Model.Tables.CodeBook;

namespace Model.Tables.Edu.SendMessage
{
    public static class SendMessageTranslationDboExt
    {
        public static SendMessageTranslationDbo FindTranslation(this ICollection<SendMessageTranslationDbo> translations, string culture)
        {
            SendMessageTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<SendMessageTranslationDbo> PrepareTranslation(
            this ICollection<SendMessageTranslationDbo> translations,
            string subject,
            string html,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            SendMessageTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new SendMessageTranslationDbo()
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
