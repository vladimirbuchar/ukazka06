﻿using Core.Base.Filter;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseTerm;
using Model.Edu.OrganizationStudyHour;
using Model.Link;
using Repository.ClassRoomRepository;
using Repository.CourseLectorRepository;
using Repository.CourseTermRepository;
using Repository.OrganizationHoursRepository;
using Repository.StudentInGroupCourseTerm;
using Services.CourseTerm.Convertor;
using Services.CourseTerm.Dto;
using Services.CourseTerm.Validator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.CourseTerm.Service
{
    public class CourseTermService(
        IStudentInGroupCourseTermRepository studentInGroupCourseTermRepository,
        ICourseLectorRepository courseLectorRepository,
        IOrganizationStudyHourRepository organizationStudyHoursRepository,
        ICourseTermRepository courseTermRepository,
        ICourseTermConvertor courseTermConvertor,
        IClassRoomRepository classRoomRepository,
        ICourseTermValidator validator
    )
        : BaseService<
            ICourseTermRepository,
            CourseTermDbo,
            ICourseTermConvertor,
            ICourseTermValidator,
            CourseTermCreateDto,
            CourseTermListDto,
            CourseTermDetailDto,
            CourseTermUpdateDto,
            FilterRequest
        >(courseTermRepository, courseTermConvertor, validator),
            ICourseTermService
    {
        private readonly IClassRoomRepository _classRoomRepository = classRoomRepository;
        private readonly IOrganizationStudyHourRepository _organizationStudyHoursRepository = organizationStudyHoursRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;

        public override Result<CourseTermDetailDto> AddObject(CourseTermCreateDto addObject, Guid userId, string culture)
        {
            if (addObject.ClassRoomId == null)
            {
                addObject.ClassRoomId = _classRoomRepository
                    .GetEntity(false, x => x.IsOnline == true && x.Branch.OrganizationId == addObject.OrganizationId)
                    .Id;
            }
            Result<CourseTermDetailDto> result = _validator.IsValid(addObject);
            if (result.IsOk)
            {
                CourseTermDbo addCourseTerm = _convertor.ConvertToBussinessEntity(addObject, culture);
                if (addCourseTerm.OrganizationStudyHourId != null)
                {
                    List<OrganizationStudyHourDbo> getOrganizationSetting = _organizationStudyHoursRepository
                        .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId)
                        .Result;
                    addCourseTerm.TimeFromId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveFromId;
                    addCourseTerm.TimeToId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveToId;
                }

                CourseTermDbo entity = _repository.CreateEntity(addCourseTerm, userId);
                foreach (Guid item in addObject.Lector)
                {
                    _ = _courseLectorRepository.CreateEntity(
                        new CourseLectorDbo() { CourseTermId = entity.Id, UserInOrganizationId = item },
                        Guid.Empty
                    );
                }
                foreach (Guid item in addObject.StudentGroup)
                {
                    _ = _studentInGroupCourseTermRepository.CreateEntity(
                        new StudentInGroupCourseTermDbo() { CourseTermId = entity.Id, StudentGroupId = item },
                        Guid.Empty
                    );
                }
                return new Result<CourseTermDetailDto>() { Data = _convertor.ConvertToWebModel(entity, culture) };
            }
            return result;
        }
    }
}
