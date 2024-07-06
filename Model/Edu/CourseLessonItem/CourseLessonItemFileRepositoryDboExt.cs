using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.CourseLessonItem
{
    public static class CourseLessonItemFileRepositoryDboExt
    {
        public static CourseLessonItemFileRepositoryDbo FindTranslation(this ICollection<CourseLessonItemFileRepositoryDbo> translations, string culture)
        {
            CourseLessonItemFileRepositoryDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }
    }
}
