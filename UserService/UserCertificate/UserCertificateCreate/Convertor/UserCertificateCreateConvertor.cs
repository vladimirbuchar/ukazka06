using Model.Edu.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Convertor
{
    public class UserCertificateCreateConvertor : IUserCertificateCreateConvertor
    {
        public Task<UserCertificateDbo> ConvertToBussinessEntity(UserCertificateCreateDto create, string culture)
        {
            return Task.FromResult(new UserCertificateDbo()
            {
                Name = create.Name,
                FileName = create.FileName,
                UserId = create.UserId,
                ValidTo = create.ValidTo,
                ActiveFrom = DateTime.Now
            });
        }
    }
}
