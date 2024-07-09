using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly List<TimeTableDbo> _timeTables = timeTableCodebook.GetEntities(false).Result;

        public override Result<StudyHourDetailDto> UpdateObject(
            StudyHourUpdateDto update,
            Guid userId,
            string culture,
            Result<StudyHourDetailDto> result = null
        )
        {
            OrganizationStudyHourDbo organizationStudyHourDbo =
                _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            OrganizationStudyHourDbo updateStudyHours = _convertor.ConvertToBussinessEntity(update, organizationStudyHourDbo, culture);
            result = new() { Data = _convertor.ConvertToWebModel(_repository.UpdateEntity(updateStudyHours, Guid.Empty), culture) };
            return result;
        }

        public override List<StudyHourListDto> GetList(
            Expression<Func<OrganizationStudyHourDbo, bool>> predicate = null,
            bool deleted = false,
            string culture = "",
            OrganizationStudyHourFilter filter = null
        )
        {
            return _convertor.ConvertToWebModel(
                [.. _repository.GetEntities(deleted, predicate, PrepareSqlFilter(filter, culture), x => x.Position).Result],
                string.Empty
            );
        }

        public override Result<StudyHourDetailDto> AddObject(StudyHourCreateDto addObject, Guid userId, string culture)
        {
            OrganizationStudyHourDbo addStudyHours = _convertor.ConvertToBussinessEntity(addObject, culture);
            if (addStudyHours.ActiveFromId != Guid.Empty && addStudyHours.ActiveToId == Guid.Empty && addObject.LessonLength > 0)
            {
                TimeTableDbo timeTable = _timeTables.FirstOrDefault(x => x.Id == addStudyHours.ActiveFromId);
                if (timeTable != null)
                {
                    addStudyHours.ActiveToId = _timeTables.FirstOrDefault(x => x.Priority == timeTable.Priority + (addObject.LessonLength / 5)).Id;
                }
            }
            Result<StudyHourDetailDto> result =
                new() { Data = _convertor.ConvertToWebModel(_repository.CreateEntity(addStudyHours, userId), culture) };
            return result;
        }
    }
}
