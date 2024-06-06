using Model.Tables.CodeBook;
using System.Collections.Generic;
using System.Linq;

namespace Model.Tables.Edu.ClassRoom
{
    public static class ClassRoomTranslationDboExt
    {
        public static ClassRoomTranslationDbo FindTranslation(this ICollection<ClassRoomTranslationDbo> translations, string culture)
        {
            ClassRoomTranslationDbo translation = null;
            translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            translation ??= translations.FirstOrDefault();
            return translation;
        }

        public static ICollection<ClassRoomTranslationDbo> PrepareTranslation(this ICollection<ClassRoomTranslationDbo> translations, string name, string culture, HashSet<CultureDbo> cultureList)
        {
            translations ??= [];
            ClassRoomTranslationDbo translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            if (translation == null)
            {
                translations.Add(new ClassRoomTranslationDbo() { CultureId = cultureList.FirstOrDefault(x => x.SystemIdentificator == culture).Id, Name = name });
            }
            else
            {
                translation.Name = name;
            }

            return translations;
        }
    }
}
