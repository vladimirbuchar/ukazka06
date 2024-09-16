using Core.Base.Convertor;
using Model.Edu.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Convertor
{
    public interface IUserCertificateCreateConvertor : IBaseCreateConvertor<UserCertificateDbo, UserCertificateCreateDto>
    {
    }
}