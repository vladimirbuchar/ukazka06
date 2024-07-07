using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.ClassRoom;
using Model.Edu.Course;
using Model.Edu.CourseTermDate;
using Model.Edu.OrganizationStudyHour;
using Repository.ClassRoomRepository;
using Repository.OrganizationHoursRepository;
using Services.ClassRoom.Convertor;
using Services.ClassRoom.Dto;
using Services.ClassRoom.Validator;
using Services.OrganizationStudyHour.Dto;
using Services.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.ClassRoom.Service
{
    public class ClassRoomService(
        IOrganizationStudyHourRepository organizationStudyHourRepository,
        IClassRoomRepository classRoomRepository,
        IClassRoomConvertor classRoomConvertor,
        IClassRoomValidator validator
    )
        : BaseService<IClassRoomRepository, ClassRoomDbo, IClassRoomConvertor, IClassRoomValidator, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto>(
            classRoomRepository,
            classRoomConvertor,
            validator
        ),
            IClassRoomService
    {
        private readonly IOrganizationStudyHourRepository _organizationStudyHourRepository = organizationStudyHourRepository;

        public ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture)
        {
            ClassRoomTimeTableDto getClassRoomTimeTableDtos = new();
            HashSet<CourseTermDateDbo> getClassRoomTimeTables = [.. _repository.GetEntity(false, x => x.Id == classRoomId).CourseTermDates];
            HashSet<OrganizationStudyHourDbo> getStudyHours = [.. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == organizationId, x => x.Position)];
            getClassRoomTimeTableDtos.StudyHours = getStudyHours
                .Select(x => new StudyHourListDto()
                {
                    ActiveFrom = x.ActiveFrom.Value,
                    ActiveFromId = x.ActiveFromId,
                    ActiveTo = x.ActiveTo.Value,
                    ActiveToId = x.ActiveToId,
                    Id = x.Id,
                    Position = x.Position
                })
                .ToHashSet();
            HashSet<CourseTermDateDbo> monday = getClassRoomTimeTables.Where(x => x.CourseTerm.Monday).ToHashSet();
            HashSet<CourseTermDateDbo> tuesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Tuesday).ToHashSet();
            HashSet<CourseTermDateDbo> wednesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Wednesday).ToHashSet();
            HashSet<CourseTermDateDbo> thursday = getClassRoomTimeTables.Where(x => x.CourseTerm.Thursday).ToHashSet();
            HashSet<CourseTermDateDbo> friday = getClassRoomTimeTables.Where(x => x.CourseTerm.Friday).ToHashSet();
            HashSet<CourseTermDateDbo> saturday = getClassRoomTimeTables.Where(x => x.CourseTerm.Saturday).ToHashSet();
            HashSet<CourseTermDateDbo> sunday = getClassRoomTimeTables.Where(x => x.CourseTerm.Sunday).ToHashSet();
            PrepareTimeTable(monday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_MONDAY, culture);
            PrepareTimeTable(tuesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_TUESDAY, culture);
            PrepareTimeTable(wednesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_WEDNESDAY, culture);
            PrepareTimeTable(thursday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_THURSDAY, culture);
            PrepareTimeTable(friday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_FRIDAY, culture);
            PrepareTimeTable(saturday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SATURDAY, culture);
            PrepareTimeTable(sunday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SUNDAY, culture);
            return getClassRoomTimeTableDtos;
        }

        private static void PrepareTimeTable(HashSet<CourseTermDateDbo> day, HashSet<OrganizationStudyHourDbo> getStudyHours, ClassRoomTimeTableDto timeTableItem, string dayName, string culture)
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.TimeFromId == item.ActiveFromId && x.TimeToId == item.ActiveToId)?.CourseTerm.Course.CourseTranslations.FindTranslation(culture).Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            _ = timeTableItem.TimeTable.Add(timeTableDto);
        }
        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            ClassRoomDbo classRoomDbo = _repository.GetEntity(objectId);
            if (classRoomDbo != null && classRoomDbo.IsOnline)
            {
                Result result = new();
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.CLASS_ROOM, MessageItem.CAN_NOT_DELETE));
                return result;
            }
            return base.DeleteObject(objectId, userId);
        }
    }
}
