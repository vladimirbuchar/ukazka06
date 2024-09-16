using Core.Base.Command.Create;
using Model.Edu.UserCertificate;
using Repository.UserCertificate;
using UserService.UserCertificate.UserCertificateCreate.Convertor;
using UserService.UserCertificate.UserCertificateCreate.Dto;
using UserService.UserCertificate.UserCertificateCreate.Validator;

namespace UserService.UserCertificate.UserCertificateCreate.Command
{
    public class UserCertificateCreateCommand : BaseCreateCommand<UserCertificateDbo, IUserCertificateRepository, UserCertificateCreateDto, IUserCertificateCreateConvertor, IUserCertificateCreateValidator>, IUserCertificateCreateCommand
    {
        public UserCertificateCreateCommand(IUserCertificateRepository repository, IUserCertificateCreateConvertor convertor, IUserCertificateCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
