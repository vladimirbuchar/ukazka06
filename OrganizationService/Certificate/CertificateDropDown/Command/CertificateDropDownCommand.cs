using Core.Base.Command.DropDown;
using Model.Edu.Certificate;
using OrganizationService.Certificate.CertificateDropDown.Convertor;
using OrganizationService.Certificate.CertificateDropDown.Dto;
using Repository.Certificate;

namespace OrganizationService.Certificate.CertificateDropDown.Command
{
    public class CertificateDropDownCommand : BaseDropDownCommand<CertificateDbo, ICertificateRepository, CertificateDropDownDto, ICertificateDropDownConvertor>, ICertificateDropDownCommand
    {
        public CertificateDropDownCommand(ICertificateRepository repository, ICertificateDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
