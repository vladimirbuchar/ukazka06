using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Question;

public static class QuestionFileRepositoryDboExt
{
    public static QuestionFileRepositoryDbo FindTranslation(
        this ICollection<QuestionFileRepositoryDbo> translations,
        List<string> cultures,
        bool findSpecificCulture = false
    )
    {
        QuestionFileRepositoryDbo translation = null;
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
