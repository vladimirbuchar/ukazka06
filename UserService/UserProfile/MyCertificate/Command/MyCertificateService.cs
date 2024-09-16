using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.UserCertificate;
using Repository.UserCertificate;
using UserService.UserProfile.MyCertificate.Convertor;
using UserService.UserProfile.MyCertificate.Dto;

namespace UserService.UserProfile.MyCertificate.Command
{
    public class MyCertificateService
        : BaseListCommand<UserCertificateDbo, IUserCertificateRepository, MyCertificateListDto, IMyCertificateConvertor, RequestFilter>,
            IMyCertificateService
    {
        public MyCertificateService(IUserCertificateRepository repository, IMyCertificateConvertor convertor)
            : base(repository, convertor) { }
    }
}
