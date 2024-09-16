using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseService.Course.CourseCreate.Dto;
using Model.CodeBook;
using Model.Edu.Course;
using Repository.Certificate;
using Repository.Course;
using Repository.CourseMaterial;
using Repository.MessageTemplate;

namespace CourseService.Course.CourseCreate.Validator
{
    public class CourseCreateValidator : BaseCreateValidator<CourseDbo, ICourseRepository, CourseCreateDto>, ICourseCreateValidator
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly ICourseMaterialRepository _courseMaterialRepository;
        private readonly IMessageTemplateRepository _messageRepository;
        private readonly ICodeBookRepository<CourseStatusDbo> _courseStatus;
        private readonly ICodeBookRepository<CourseTypeDbo> _courseType;

        public CourseCreateValidator(
            ICodeBookRepository<CourseTypeDbo> courseType,
            ICodeBookRepository<CourseStatusDbo> courseStatus,
            IMessageTemplateRepository messageRepository,
            ICourseMaterialRepository courseMaterialRepository,
            ICourseRepository repository,
            ICertificateRepository certificateRepository
        )
            : base(repository)
        {
            _certificateRepository = certificateRepository;
            _courseMaterialRepository = courseMaterialRepository;
            _messageRepository = messageRepository;
            _courseStatus = courseStatus;
            _courseType = courseType;
        }

        public override async Task<ResultInsert> IsValid(CourseCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.Price, result, MessageCategory.COURSE, Constants.PRICE_IS_LESS_THAN_ZERO);
            IsValidPostiveNumber(create.Sale, result, MessageCategory.COURSE, Constants.SALE_IS_LESS_THAN_ZERO);
            _ = IsValidStudentCount(create.DefaultMinimumStudents, create.DefaultMaximumStudents, result);
            _ = IsValidCourseStatus(create.CourseStatusId, result);
            _ = IsValidCourseType(create.CourseTypeId, result);
            _ = IsValidCertificate(create.CertificateId, result);
            _ = IsValidCourseMaterial(create.CourseMaterialId, result);
            _ = IsValidEmailTemplate(create.EmailTemplateId, result);

            return await Task.FromResult(result);
        }

        private static Result IsValidStudentCount(int defaultMinimumStudents, int defaultMaximumStudents, Result result)
        {
            if (defaultMaximumStudents < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.MAXIMUM_STUDENT_IS_LESS_THAN_ZERO));
            }
            if (defaultMinimumStudents < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.MINIMUM_STUDENT_IS_LESS_THAN_ZERO));
            }
            if (defaultMinimumStudents > defaultMaximumStudents)
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.MAXIMUM_STUDENT_IS_LESS_THAN_MINIMUM_STUDENT)
                );
            }
            return result;
        }

        private async Task<Result> IsValidCertificate(Guid? certficateId, Result result)
        {
            if (certficateId.HasValue && await _certificateRepository.GetEntity(certficateId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.CERTIFICATE, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        private async Task<Result> IsValidCourseMaterial(Guid? courseMaterialId, Result result)
        {
            if (courseMaterialId.HasValue && await _courseMaterialRepository.GetEntity(courseMaterialId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_MATERIAL, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        private async Task<Result> IsValidEmailTemplate(Guid? templateId, Result result)
        {
            if (templateId.HasValue && await _messageRepository.GetEntity(templateId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.TEMPLATE_EMAIL_NOT_EXIST));
            }
            return result;
        }

        private async Task<Result> IsValidCourseStatus(Guid courseStatus, Result result)
        {
            CourseStatusDbo status = await _courseStatus.GetEntity(courseStatus);
            if (status == null || status.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.INVALID_COURSE_STATUS));
            }
            return result;
        }

        private async Task<Result> IsValidCourseType(Guid courseType, Result result)
        {
            CourseTypeDbo type = await _courseType.GetEntity(courseType);
            if (type == null || type.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, Constants.INVALID_COURSE_TYPE));
            }
            return result;
        }
    }
}
