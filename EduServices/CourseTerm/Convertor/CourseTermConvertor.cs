﻿using Core.Extension;
using EduServices.CourseTerm.Dto;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.CourseTerm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.CourseTerm.Convertor
{
    public class CourseTermConvertor : ICourseTermConvertor
    {
        public CourseTermDbo ConvertToBussinessEntity(CourseTermCreateDto addCourseTermDto, string culture)
        {
            Guid organizationStudyHourId = Guid.Empty;
            if (!addCourseTermDto.OrganizationStudyHourId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(addCourseTermDto.OrganizationStudyHourId, out organizationStudyHourId);
            }
            return new CourseTermDbo()
            {
                ActiveFrom = addCourseTermDto.ActiveFrom,
                ActiveTo = addCourseTermDto.ActiveTo,
                ClassRoomId = addCourseTermDto.ClassRoomId ?? Guid.Empty,
                CourseId = addCourseTermDto.CourseId,
                Friday = addCourseTermDto.Friday,
                MaximumStudent = addCourseTermDto.MaximumStudents,
                MinimumStudent = addCourseTermDto.MinimumStudents,
                Monday = addCourseTermDto.Monday,
                Price = addCourseTermDto.Price,
                RegistrationFrom = addCourseTermDto.RegistrationFrom,
                RegistrationTo = addCourseTermDto.RegistrationTo,
                Sale = addCourseTermDto.Sale,
                Saturday = addCourseTermDto.Saturday,
                Sunday = addCourseTermDto.Sunday,
                Thursday = addCourseTermDto.Thursday,
                TimeFromId = addCourseTermDto.TimeFromId,
                TimeToId = addCourseTermDto.TimeToId,
                Tuesday = addCourseTermDto.Tuesday,
                Wednesday = addCourseTermDto.Wednesday,
                OrganizationStudyHourId = addCourseTermDto.OrganizationStudyHourId.IsNullOrEmptyWithTrim() || organizationStudyHourId == Guid.Empty ? null : organizationStudyHourId
            };
        }

        public HashSet<CourseTermListDto> ConvertToWebModel(HashSet<CourseTermDbo> getTermInCourses, string culture)
        {
            return getTermInCourses
                .Select(item => new CourseTermListDto()
                {
                    Branch = item.ClassRoom.Branch.BranchTranslations.FindTranslation(culture).Name,
                    ClassRoom = item.ClassRoom.ClassRoomTranslations.FindTranslation(culture).Name,
                    CourseId = item.CourseId,
                    Id = item.Id,
                    TimeFrom = item.TimeFrom.Value,
                    TimeTo = item.TimeTo.Value,
                    ActiveFrom = item.ActiveFrom.Value,
                    ActiveTo = item.ActiveTo.Value,
                    Monday = item.Monday,
                    Saturday = item.Saturday,
                    Sunday = item.Sunday,
                    Thursday = item.Thursday,
                    Tuesday = item.Tuesday,
                    Wednesday = item.Wednesday,
                    Friday = item.Friday,
                    BranchId = item.ClassRoom.BranchId,
                    ClassRoomId = item.ClassRoomId,
                    IsActive = item.IsActive.HasValue && item.IsActive.Value
                })
                .ToHashSet();
        }

        public CourseTermDetailDto ConvertToWebModel(CourseTermDbo getCourseTermDetail, string culture)
        {
            return new CourseTermDetailDto()
            {
                ActiveFrom = getCourseTermDetail.ActiveFrom.Value,
                Id = getCourseTermDetail.Id,
                Wednesday = getCourseTermDetail.Wednesday,
                ActiveTo = getCourseTermDetail.ActiveTo.Value,
                ClassRoomId = getCourseTermDetail.ClassRoomId,
                BranchId = getCourseTermDetail.ClassRoom.BranchId,
                Price = getCourseTermDetail.Price,
                Sale = getCourseTermDetail.Sale,
                Friday = getCourseTermDetail.Friday,
                MaximumStudent = getCourseTermDetail.MaximumStudent,
                MinimumStudent = getCourseTermDetail.MinimumStudent,
                Monday = getCourseTermDetail.Monday,
                RegistrationFrom = getCourseTermDetail.RegistrationFrom.Value,
                RegistrationTo = getCourseTermDetail.RegistrationTo.Value,
                Saturday = getCourseTermDetail.Saturday,
                Sunday = getCourseTermDetail.Sunday,
                Thursday = getCourseTermDetail.Thursday,
                TimeFromId = getCourseTermDetail.TimeFromId,
                TimeToId = getCourseTermDetail.TimeToId,
                Tuesday = getCourseTermDetail.Tuesday,
                OrganizationStudyHourId = getCourseTermDetail.OrganizationStudyHourId
            };
        }

        public CourseTermDbo ConvertToBussinessEntity(CourseTermUpdateDto updateCourseTermDto, CourseTermDbo entity, string culture)
        {
            Guid organizationStudyHourId = Guid.Empty;
            if (!updateCourseTermDto.OrganizationStudyHourId.IsNullOrEmptyWithTrim())
            {
                _ = Guid.TryParse(updateCourseTermDto.OrganizationStudyHourId, out organizationStudyHourId);
            }
            entity.ActiveFrom = updateCourseTermDto.ActiveFrom;
            entity.ActiveTo = updateCourseTermDto.ActiveTo;
            entity.ClassRoomId = updateCourseTermDto.ClassRoomId ?? Guid.Empty;
            entity.Price = updateCourseTermDto.Price;
            entity.Sale = updateCourseTermDto.Sale;
            entity.Friday = updateCourseTermDto.Friday;
            entity.Monday = updateCourseTermDto.Monday;
            entity.RegistrationFrom = updateCourseTermDto.RegistrationFrom;
            entity.RegistrationTo = updateCourseTermDto.RegistrationTo;
            entity.Saturday = updateCourseTermDto.Saturday;
            entity.MaximumStudent = updateCourseTermDto.MaximumStudents;
            entity.MinimumStudent = updateCourseTermDto.MinimumStudents;
            entity.Sunday = updateCourseTermDto.Sunday;
            entity.Thursday = updateCourseTermDto.Thursday;
            entity.TimeFromId = updateCourseTermDto.TimeFromId;
            entity.TimeToId = updateCourseTermDto.TimeToId;
            entity.Tuesday = updateCourseTermDto.Tuesday;
            entity.Wednesday = updateCourseTermDto.Wednesday;
            entity.OrganizationStudyHourId = updateCourseTermDto.OrganizationStudyHourId.IsNullOrEmptyWithTrim() || organizationStudyHourId == Guid.Empty ? Guid.Empty : organizationStudyHourId;
            return entity;
        }
    }
}
