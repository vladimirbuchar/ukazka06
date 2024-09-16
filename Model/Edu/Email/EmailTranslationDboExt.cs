using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Email
{
    public static class EmailTranslationDboExt
    {
        public static EmailTranslationDbo FindTranslation(this ICollection<EmailTranslationDbo> translations, List<string> cultures)
        {
            EmailTranslationDbo translation = null;
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

        public static ICollection<EmailTranslationDbo> PrepareTranslation(
            this ICollection<EmailTranslationDbo> translations,
            string subject,
            string emailBodyHtml,
            string emailBody,
            Guid cultureId
        )
        {
            translations ??= [];
            EmailTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new EmailTranslationDbo()
                    {
                        CultureId = cultureId,
                        Subject = subject,
                        EmailBodyHtml = emailBodyHtml,
                        EmailBodyPlainText = emailBody,
                    }
                );
            }
            else
            {
                translation.Subject = subject;
                translation.EmailBodyHtml = emailBodyHtml;
                translation.EmailBodyPlainText = emailBody;
            }

            return translations;
        }
    }
}
