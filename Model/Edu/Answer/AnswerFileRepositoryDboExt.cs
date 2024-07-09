using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Answer
{
    public static class AnswerFileRepositoryDboExt
    {
        public static AnswerFileRepositoryDbo FindTranslation(
            this ICollection<AnswerFileRepositoryDbo> translations,
            string culture,
            bool findSpecificCulture = false
        )
        {
            AnswerFileRepositoryDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (!findSpecificCulture)
            {
                translation ??= translations.FirstOrDefault();
            }
            return translation;
        }
    }
}
