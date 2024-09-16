using Core.Base.Validator;
using Model.Edu.UserCertificate;
using Repository.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Dto;

namespace UserService.UserCertificate.UserCertificateCreate.Validator
{
    public class UserCertificateCreateValidator : BaseCreateValidator<UserCertificateDbo, IUserCertificateRepository, UserCertificateCreateDto>, IUserCertificateCreateValidator
    {
        public UserCertificateCreateValidator(IUserCertificateRepository repository) : base(repository)
        {
        }
    }
}
