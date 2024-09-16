using Core.Base.Convertor;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDropDown.Dto;

namespace OrganizationService.Certificate.CertificateDropDown.Convertor
{
    public interface ICertificateDropDownConvertor : IBaseDropDownConvertor<CertificateDbo, CertificateDropDownDto>
    {
    }
}