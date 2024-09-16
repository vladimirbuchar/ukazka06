using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Certificate
{
    public static class CertificateTranslationDboExt
    {
        public static CertificateTranslationDbo FindTranslation(this ICollection<CertificateTranslationDbo> translations, List<string> cultures)
        {
            CertificateTranslationDbo translation = null;
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

        public static ICollection<CertificateTranslationDbo> PrepareTranslation(
            this ICollection<CertificateTranslationDbo> translations,
            string name,
            string html,
            Guid cultureId
        )
        {
            translations ??= [];
            CertificateTranslationDbo translation = translations.FirstOrDefault(x => x.CultureId == cultureId);
            if (translation == null)
            {
                translations.Add(
                    new CertificateTranslationDbo()
                    {
                        CultureId = cultureId,
                        Name = name,
                        Html = html,
                    }
                );
            }
            else
            {
                translation.Name = name;
                translation.Html = html;
            }

            return translations;
        }
    }
}
