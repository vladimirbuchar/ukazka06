using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Certificate;
using Services.Certificate.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Certificate.Convertor
{
    public class CertificateConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : ICertificateConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<CertificateDbo> ConvertToBussinessEntity(CertificateCreateDto addCertificateDto, string culture)
        {
            CertificateDbo certificate =
                new() { OrganizationId = addCertificateDto.OrganizationId, CertificateValidTo = addCertificateDto.CertificateValidTo };
            certificate.CertificateTranslations = certificate.CertificateTranslations.PrepareTranslation(
                addCertificateDto.Name,
                addCertificateDto.Html,
                culture,
                _cultureList
            );
            return Task.FromResult(certificate);
        }

        public Task<CertificateDbo> ConvertToBussinessEntity(CertificateUpdateDto updateCertificateDto, CertificateDbo entity, string culture)
        {
            entity.CertificateTranslations = entity.CertificateTranslations.PrepareTranslation(
                updateCertificateDto.Name,
                updateCertificateDto.Html,
                culture,
                _cultureList
            );
            entity.CertificateValidTo = updateCertificateDto.CertificateValidTo;
            return Task.FromResult(entity);
        }

        public Task<List<CertificateListDto>> ConvertToWebModel(List<CertificateDbo> getCertificateInOrganizations, string culture)
        {
            return Task.FromResult(getCertificateInOrganizations
                .Select(item => new CertificateListDto()
                {
                    Id = item.Id,
                    Name = item.CertificateTranslations.FindTranslation(culture).Name,
                    CertificateValidTo = item.CertificateValidTo
                })
                .ToList());
        }

        public Task<CertificateDetailDto> ConvertToWebModel(CertificateDbo getCertificateDetail, string culture)
        {
            return Task.FromResult(new CertificateDetailDto()
            {
                Html = getCertificateDetail.CertificateTranslations.FindTranslation(culture).Html,
                Id = getCertificateDetail.Id,
                Name = getCertificateDetail.CertificateTranslations.FindTranslation(culture).Name,
                CertificateValidTo = getCertificateDetail.CertificateValidTo
            });
        }
    }
}
