using Model.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.StudentGroup
{
    public static class StudentGroupTranslationDboExt
    {
        public static StudentGroupTranslationDbo FindTranslation(this ICollection<StudentGroupTranslationDbo> translations, string culture)
        {
            StudentGroupTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<StudentGroupTranslationDbo> PrepareTranslation(
            this ICollection<StudentGroupTranslationDbo> translations,
            string name,
            string culture,
            HashSet<CultureDbo> cultureList
        )
        {
            translations ??= [];
            StudentGroupTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new StudentGroupTranslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Name = name, });
            }
            else
            {
                translation.Name = name;
            }
            return translations;
        }
    }
}
