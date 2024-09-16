using Core.Base.Command.DropDown;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDropDown.Dto;

namespace OrganizationService.Certificate.CertificateDropDown.Command
{
    public interface ICertificateDropDownCommand : IBaseDropDownCommand<CertificateDbo, CertificateDropDownDto>
    {
    }
}