using Core.Base.Command.List;
using Core.Base.Filter;
using Model.Edu.UserCertificate;
using UserService.UserProfile.MyCertificate.Dto;

namespace UserService.UserProfile.MyCertificate.Command
{
    public interface IMyCertificateService : IBaseListCommand<UserCertificateDbo, MyCertificateListDto, RequestFilter> { }
}
