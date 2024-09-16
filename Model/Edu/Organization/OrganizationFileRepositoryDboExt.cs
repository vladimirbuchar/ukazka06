using System.Collections.Generic;
using System.Linq;

namespace Model.Edu.Organization
{
    public static class OrganizationFileRepositoryDboExt
    {
        public static OrganizationFileRepositoryDbo FindTranslation(
            this ICollection<OrganizationFileRepositoryDbo> translations,
            List<string> cultures,
            bool findSpecificCulture = false
        )
        {
            OrganizationFileRepositoryDbo translation = null;
            foreach (string culture in cultures)
            {
                translation = translations.FirstOrDefault(x => x.Culture.SystemIdentificator == culture);
            }
            if (!findSpecificCulture)
            {
                translation ??= translations.FirstOrDefault();
            }
            return translation;
        }
    }
}
