using Core.Base.Service;
using EduRepository.CertificateRepository;
using EduServices.Certificate.Convertor;
using EduServices.Certificate.Dto;
using EduServices.Certificate.Validator;
using Model.Edu.Certificate;

namespace EduServices.Certificate.Service
{
    public class CertificateService(ICertificateRepository certificateRepository, ICertificateConvertor certificateConvertor, ICertificateValidator validator)
        : BaseService<ICertificateRepository, CertificateDbo, ICertificateConvertor, ICertificateValidator, CertificateCreateDto, CertificateListDto, CertificateDetailDto, CertificateUpdateDto>(
            certificateRepository,
            certificateConvertor,
            validator
        ),
            ICertificateService { }
}
