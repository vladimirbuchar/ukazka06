using Core.Base.Service;
using Model.Edu.Certificate;
using Repository.CertificateRepository;
using Services.Certificate.Convertor;
using Services.Certificate.Dto;
using Services.Certificate.Validator;

namespace Services.Certificate.Service
{
    public class CertificateService(ICertificateRepository certificateRepository, ICertificateConvertor certificateConvertor, ICertificateValidator validator)
        : BaseService<ICertificateRepository, CertificateDbo, ICertificateConvertor, ICertificateValidator, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto>(
            certificateRepository,
            certificateConvertor,
            validator
        ),
            ICertificateService
    { }
}
