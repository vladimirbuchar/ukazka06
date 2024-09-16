using Core.Constants;
using Microsoft.Extensions.Configuration;
using Model.Edu.UserCertificate;
using UserService.UserProfile.MyCertificate.Dto;

namespace UserService.UserProfile.MyCertificate.Convertor
{
    public class MyCertificateConvertor : IMyCertificateConvertor
    {
        private readonly IConfiguration _configuration;

        public MyCertificateConvertor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<List<MyCertificateListDto>> ConvertToWebModel(List<UserCertificateDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(x => new MyCertificateListDto()
                {
                    ActiveFrom = x.ActiveFrom,
                    Description = "",
                    FileName = string.Format(
                            "{0}{2}/{1}.pdf",
                            _configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value,
                            x.FileName,
                            ConfigValue.CERTIFICATE_PATH
                        ),
                    Name = x.Name
                })
                    .ToList()
            );
        }
    }
}
