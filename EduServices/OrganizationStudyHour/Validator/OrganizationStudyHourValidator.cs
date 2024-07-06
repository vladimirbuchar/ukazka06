using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.OrganizationHoursRepository;
using EduRepository.OrganizationRepository;
using EduServices.OrganizationStudyHour.Dto;
using Model.CodeBook;
using Model.Edu.OrganizationStudyHour;
using System;

namespace EduServices.OrganizationStudyHour.Validator
{
    public class OrganizationStudyHourValidator(IOrganizationStudyHourRepository repository, IOrganizationRepository organizationRepository, ICodeBookRepository<TimeTableDbo> timeTable)
        : BaseValidator<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, StudyHourCreateDto, StudyHourDetailDto, StudyHourUpdateDto>(repository),
            IOrganizationStudyHourValidator
    {
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly ICodeBookRepository<TimeTableDbo> _timeTable = timeTable;

        public override Result<StudyHourDetailDto> IsValid(StudyHourCreateDto create)
        {
            Result<StudyHourDetailDto> validate = new();
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!create.ActiveFromId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(create.ActiveFromId, out activeFromId);
            }
            if (!create.ActiveToId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(create.ActiveToId, out activeToId);
            }

            if (_organizationRepository.GetEntity(create.OrganizationId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.ORGANIZATION, GlobalValue.NOT_EXISTS));
            }
            if (_timeTable.GetEntity(activeFromId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_FROM, GlobalValue.NOT_EXISTS));
            }

            if (_timeTable.GetEntity(activeToId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_TO, GlobalValue.NOT_EXISTS));
            }
            return validate;
        }

        public override Result<StudyHourDetailDto> IsValid(StudyHourUpdateDto update)
        {
            Result<StudyHourDetailDto> validate = new();
            Guid activeFromId = Guid.Empty;
            Guid activeToId = Guid.Empty;
            if (!update.ActiveFromId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(update.ActiveFromId, out activeFromId);
            }
            if (!update.ActiveToId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(update.ActiveToId, out activeToId);
            }

            if (_timeTable.GetEntity(activeFromId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_FROM, GlobalValue.NOT_EXISTS));
            }

            if (_timeTable.GetEntity(activeToId) == null)
            {
                validate.AddResultStatus(new ValidationMessage(MessageType.ERROR, Constants.TIME_TABLE_TO, GlobalValue.NOT_EXISTS));
            }
            return validate;
        }
    }
}
