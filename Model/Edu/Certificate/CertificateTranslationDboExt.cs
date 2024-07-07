using Model.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Certificate
{
    public static class CertificateTranslationDboExt
    {
        public static CertificateTranslationDbo FindTranslation(this ICollection<CertificateTranslationDbo> translations, string culture)
        {
            CertificateTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<CertificateTranslationDbo> PrepareTranslation(
            this ICollection<CertificateTranslationDbo> translations,
            string name,
            string html,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            CertificateTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(
                    new CertificateTranslationDbo()
                    {
                        CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id,
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
