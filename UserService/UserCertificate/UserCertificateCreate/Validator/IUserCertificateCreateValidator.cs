using Core.Base.Validator;
using Model.Edu.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Validator
{
    public interface IUserCertificateCreateValidator : IBaseCreateValidator<UserCertificateDbo, UserCertificateCreateDto>
    {
    }
}