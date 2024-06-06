using System.Collections.Generic;
using System.Linq;

namespace Model.Tables.Edu.TestQuestion;

public static class QuestionFileRepositoryDboExt
{
    public static QuestionFileRepositoryDbo FindTranslation(this ICollection<QuestionFileRepositoryDbo> translations, string culture, bool findSpecificCulture = false)
    {
        QuestionFileRepositoryDbo translation = null;
        translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
        if (!findSpecificCulture)
        {
            translation ??= translations.FirstOrDefault();
        }
        return translation;
    }
}
