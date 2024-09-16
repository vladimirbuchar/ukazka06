using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Answer
{
    public static class AnswerFileRepositoryDboExt
    {
        public static AnswerFileRepositoryDbo FindTranslation(
            this ICollection<AnswerFileRepositoryDbo> translations,
            List<string> cultures,
            bool findSpecificCulture = false
        )
        {
            AnswerFileRepositoryDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
                if (translation != null)
                {
                    return translation;
                }
            }
            if (!findSpecificCulture)
            {
                translation ??= translations.FirstOrDefault();
            }
            return translation;
        }
    }
}
