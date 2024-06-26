﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CertificateRepository;
using EduRepository.CourseMaterialRepository;
using EduRepository.CourseRepository;
using EduRepository.OrganizationRepository;
using EduRepository.SendMessageRepository;
using EduServices.Course.Dto;
using Model.Tables.CodeBook;
using Model.Tables.Edu.Course;
using System;

namespace EduServices.Course.Validator
{
    public class CourseValidator(
        IOrganizationRepository organizationRepository,
        ISendMessageRepository sendMessageRepository,
        ICourseMaterialRepository courseMaterialRepository,
        ICertificateRepository certificateRepository,
        ICourseRepository repository,
        ICodeBookRepository<CourseTypeDbo> courseTypeCodeBook,
        ICodeBookRepository<CourseStatusDbo> courseStatusCodeBook
    ) : BaseValidator<CourseDbo, ICourseRepository, CourseCreateDto, CourseDetailDto, CourseUpdateDto>(repository), ICourseValidator
    {
        private readonly ICodeBookRepository<CourseTypeDbo> _courseTypeCodeBook = courseTypeCodeBook;
        private readonly ICodeBookRepository<CourseStatusDbo> _courseStatusCodeBook = courseStatusCodeBook;
        private readonly ICertificateRepository _certificateRepository = certificateRepository;
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;
        private readonly ISendMessageRepository _sendMessageRepository = sendMessageRepository;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;

        public override Result<CourseDetailDto> IsValid(CourseCreateDto create)
        {
            Result<CourseDetailDto> result = new();
            IsValidString(create.Name, result, ErrorCategory.COURSE, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.Price, result, ErrorCategory.COURSE, Constants.PRICE_IS_LESS_THAN_ZERO);
            IsValidPostiveNumber(create.Sale, result, ErrorCategory.COURSE, Constants.SALE_IS_LESS_THAN_ZERO);
            _ = IsValidStudentCount(create.DefaultMinimumStudents, create.DefaultMaximumStudents, result);
            _ = IsValidCourseStatus(create.CourseStatusId, result);
            _ = IsValidCourseType(create.CourseTypeId, result);
            _ = IsValidCertificate(create.CertificateId, result);
            _ = IsValidCourseMaterial(create.CourseMaterialId, result);
            _ = IsValidEmailTemplate(create.EmailTemplateId, result);
            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }

            return result;
        }

        public override Result<CourseDetailDto> IsValid(CourseUpdateDto update)
        {
            Result<CourseDetailDto> result = new();
            IsValidString(update.Name, result, ErrorCategory.COURSE, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.Price, result, ErrorCategory.COURSE, Constants.PRICE_IS_LESS_THAN_ZERO);
            IsValidPostiveNumber(update.Sale, result, ErrorCategory.COURSE, Constants.SALE_IS_LESS_THAN_ZERO);
            _ = IsValidStudentCount(update.DefaultMinimumStudents, update.DefaultMaximumStudents, result);
            _ = IsValidCourseStatus(update.CourseStatusId, result);
            _ = IsValidCourseType(update.CourseTypeId, result);
            _ = IsValidCertificate(update.CertificateId, result);
            _ = IsValidCourseMaterial(update.CourseMaterialId, result);
            _ = IsValidEmailTemplate(update.EmailTemplateId, result);
            return result;
        }

        private static Result IsValidStudentCount(int defaultMinimumStudents, int defaultMaximumStudents, Result result)
        {
            if (defaultMaximumStudents < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.MAXIMUM_STUDENT_IS_LESS_THAN_ZERO));
            }
            if (defaultMinimumStudents < 0)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.MINIMUM_STUDENT_IS_LESS_THAN_ZERO));
            }
            if (defaultMinimumStudents > defaultMaximumStudents)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.MAXIMUM_STUDENT_IS_LESS_THAN_MINIMUM_STUDENT));
            }
            return result;
        }

        private Result IsValidCertificate(Guid? certficateId, Result result)
        {
            if (certficateId.HasValue && _certificateRepository.GetEntity(certficateId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.CERTIFICATE, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        private Result IsValidCourseMaterial(Guid? courseMaterialId, Result result)
        {
            if (courseMaterialId.HasValue && _courseMaterialRepository.GetEntity(courseMaterialId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE_MATERIAL, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        private Result IsValidEmailTemplate(Guid? templateId, Result result)
        {
            if (templateId.HasValue && _sendMessageRepository.GetEntity(templateId.Value) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.TEMPLATE_EMAIL_NOT_EXIST));
            }
            return result;
        }

        private Result IsValidCourseStatus(Guid courseStatus, Result result)
        {
            CourseStatusDbo status = _courseStatusCodeBook.GetEntity(courseStatus);
            if (status == null || status.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.INVALID_COURSE_STATUS));
            }
            return result;
        }

        private Result IsValidCourseType(Guid courseType, Result result)
        {
            CourseTypeDbo type = _courseTypeCodeBook.GetEntity(courseType);
            if (type == null || type.SystemIdentificator == CodebookValue.CODEBOOK_SELECT_VALUE)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, ErrorCategory.COURSE, Constants.INVALID_COURSE_TYPE));
            }
            return result;
        }
    }
}
