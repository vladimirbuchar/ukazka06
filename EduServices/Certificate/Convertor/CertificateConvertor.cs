﻿using Core.Base.Repository.CodeBookRepository;
using EduServices.Certificate.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Certificate;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Certificate.Convertor
{
    public class CertificateConvertor(ICodeBookRepository<CultureDbo> codeBookService) : ICertificateConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetCodeBookItems();

        public CertificateDbo ConvertToBussinessEntity(CertificateCreateDto addCertificateDto, string culture)
        {
            CertificateDbo certificate = new() { OrganizationId = addCertificateDto.OrganizationId, CertificateValidTo = addCertificateDto.CertificateValidTo };
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

        public HashSet<CertificateListDto> ConvertToWebModel(HashSet<CertificateDbo> getCertificateInOrganizations, string culture)
        {
            return getCertificateInOrganizations
                .Select(item => new CertificateListDto()
                {
                    Id = item.Id,
                    Html = item.CertificateTranslations.FindTranslation(culture).Html,
                    Name = item.CertificateTranslations.FindTranslation(culture).Name
                })
                .ToHashSet();
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
