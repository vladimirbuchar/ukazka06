using Core.Base.Convertor;
using Model.Edu.UserCertificate;
using UserService.UserProfile.MyCertificate.Dto;

namespace UserService.UserProfile.MyCertificate.Convertor
{
    public interface IMyCertificateConvertor : IBaseListConvertor<UserCertificateDbo, MyCertificateListDto> { }
}
