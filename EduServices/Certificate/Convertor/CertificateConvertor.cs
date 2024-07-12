using System.Collections.Generic;
using System.Linq;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Certificate;
using Services.Certificate.Dto;

namespace Services.Certificate.Convertor
{
    public class CertificateConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : ICertificateConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public CertificateDbo ConvertToBussinessEntity(CertificateCreateDto addCertificateDto, string culture)
        {
            CertificateDbo certificate =
                new() { OrganizationId = addCertificateDto.OrganizationId, CertificateValidTo = addCertificateDto.CertificateValidTo };
            certificate.CertificateTranslations = certificate.CertificateTranslations.PrepareTranslation(
                addCertificateDto.Name,
                addCertificateDto.Html,
                culture,
                _cultureList
            );
            return certificate;
        }

        public CertificateDbo ConvertToBussinessEntity(CertificateUpdateDto updateCertificateDto, CertificateDbo entity, string culture)
        {
            entity.CertificateTranslations = entity.CertificateTranslations.PrepareTranslation(
                updateCertificateDto.Name,
                updateCertificateDto.Html,
                culture,
                _cultureList
            );
            entity.CertificateValidTo = updateCertificateDto.CertificateValidTo;
            return entity;
        }

        public List<CertificateListDto> ConvertToWebModel(List<CertificateDbo> getCertificateInOrganizations, string culture)
        {
            return getCertificateInOrganizations
                .Select(item => new CertificateListDto()
                {
                    Id = item.Id,
                    Name = item.CertificateTranslations.FindTranslation(culture).Name,
                    CertificateValidTo = item.CertificateValidTo
                })
                .ToList();
        }

        public CertificateDetailDto ConvertToWebModel(CertificateDbo getCertificateDetail, string culture)
        {
            return new CertificateDetailDto()
            {
                Html = getCertificateDetail.CertificateTranslations.FindTranslation(culture).Html,
                Id = getCertificateDetail.Id,
                Name = getCertificateDetail.CertificateTranslations.FindTranslation(culture).Name,
                CertificateValidTo = getCertificateDetail.CertificateValidTo
            };
        }
    }
}
