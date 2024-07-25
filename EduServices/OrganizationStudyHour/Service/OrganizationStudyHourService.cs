using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.OrganizationStudyHour;
using Repository.OrganizationHoursRepository;
using Services.OrganizationStudyHour.Convertor;
using Services.OrganizationStudyHour.Dto;
using Services.OrganizationStudyHour.Filter;
using Services.OrganizationStudyHour.Validator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.OrganizationStudyHour.Service
{
   
    public class OrganizationStudyHourService(
        IOrganizationStudyHourRepository organizationStudyHoursRepository,
        ICodeBookRepository<TimeTableDbo> timeTableCodebook,
        IOrganizationStudyHourConvertor organizationConvertor,
        IOrganizationStudyHourValidator validator
    )
        : BaseService<
            IOrganizationStudyHourRepository,
            OrganizationStudyHourDbo,
            IOrganizationStudyHourConvertor,
            IOrganizationStudyHourValidator,
            StudyHourCreateDto,
            StudyHourListDto,
            StudyHourDetailDto,
            StudyHourUpdateDto,
            OrganizationStudyHourFilter
        >(organizationStudyHoursRepository, organizationConvertor, validator),
            IOrganizationStudyHourService
    {
        private readonly ICodeBookRepository<TimeTableDbo> _timeTables = timeTableCodebook;

        public override async Task<Result<StudyHourDetailDto>> UpdateObject(
            StudyHourUpdateDto update,
            Guid userId,
            string culture,
            Result<StudyHourDetailDto> result = null
        )
        {
            OrganizationStudyHourDbo organizationStudyHourDbo = await
                _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            OrganizationStudyHourDbo updateStudyHours = await _convertor.ConvertToBussinessEntity(update, organizationStudyHourDbo, culture);
            result = new() { Data = await _convertor.ConvertToWebModel(await _repository.UpdateEntity(updateStudyHours, Guid.Empty), culture) };
            return result;
        }


        public override async Task<Result> AddObject(StudyHourCreateDto addObject, Guid userId, string culture)
        {
            OrganizationStudyHourDbo addStudyHours = await _convertor.ConvertToBussinessEntity(addObject, culture);
            if (addStudyHours.ActiveFromId != Guid.Empty && addStudyHours.ActiveToId == Guid.Empty && addObject.LessonLength > 0)
            {
                TimeTableDbo timeTable = await _timeTables.GetEntity(false, x => x.Id == addStudyHours.ActiveFromId);
                if (timeTable != null)
                {
                    addStudyHours.ActiveToId = (await _timeTables.GetEntity(false, x => x.Priority == timeTable.Priority + (addObject.LessonLength / 5))).Id;
                }
            }
            Result<StudyHourDetailDto> result =
                new() { Data = await _convertor.ConvertToWebModel(await _repository.CreateEntity(addStudyHours, userId), culture) };
            return result;
        }
    }
}
