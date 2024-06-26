﻿using Core.Base.Repository.CodeBookRepository;
using Core.Base.Service;
using Core.DataTypes;
using EduRepository.OrganizationHoursRepository;
using EduServices.OrganizationStudyHour.Convertor;
using EduServices.OrganizationStudyHour.Dto;
using EduServices.OrganizationStudyHour.Validator;
using Model.Tables.CodeBook;
using Model.Tables.Edu.OrganizationStudyHour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EduServices.OrganizationStudyHour.Service
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
            StudyHourUpdateDto
        >(organizationStudyHoursRepository, organizationConvertor, validator),
            IOrganizationStudyHourService
    {
        private readonly HashSet<TimeTableDbo> _timeTables = timeTableCodebook.GetCodeBookItems();

        public override Result<StudyHourDetailDto> UpdateObject(StudyHourUpdateDto update, Guid userId, string culture, Result<StudyHourDetailDto> result = null)
        {
            OrganizationStudyHourDbo organizationStudyHourDbo = _repository.GetEntity(update.Id) ?? throw new KeyNotFoundException(update.Id.ToString());
            OrganizationStudyHourDbo updateStudyHours = _convertor.ConvertToBussinessEntity(update, organizationStudyHourDbo, culture);
            result = new() { Data = _convertor.ConvertToWebModel(_repository.UpdateEntity(updateStudyHours, Guid.Empty), culture) };
            return result;
        }

        public override HashSet<StudyHourListDto> GetList(Expression<Func<OrganizationStudyHourDbo, bool>> predicate = null, bool deleted = false, string culture = "")
        {
            return _convertor.ConvertToWebModel([.. _repository.GetEntities(deleted, predicate).OrderBy(x => x.Position)], string.Empty);
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
            Result<StudyHourDetailDto> result = new() { Data = _convertor.ConvertToWebModel(_repository.CreateEntity(addStudyHours, userId), culture) };
            return result;
        }
    }
}
