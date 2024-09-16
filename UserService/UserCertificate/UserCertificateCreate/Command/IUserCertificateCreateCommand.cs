using Core.Base.Command.Create;
using Model.Edu.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Command
{
    public interface IUserCertificateCreateCommand : IBaseCreateCommand<UserCertificateDbo, UserCertificateCreateDto>
    {
    }
}