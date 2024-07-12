using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.Branch;
using Model.Edu.Certificate;
using Model.Edu.ClassRoom;
using Model.Edu.Course;
using Model.Edu.CourseTermDate;
using Model.Edu.OrganizationStudyHour;
using Repository.BranchRepository;
using Repository.ClassRoomRepository;
using Repository.OrganizationHoursRepository;
using Services.ClassRoom.Convertor;
using Services.ClassRoom.Dto;
using Services.ClassRoom.Filter;
using Services.ClassRoom.Sort;
using Services.ClassRoom.Validator;
using Services.OrganizationStudyHour.Dto;
using Services.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.ClassRoom.Service
{
    public class ClassRoomService(
        IOrganizationStudyHourRepository organizationStudyHourRepository,
        IClassRoomRepository classRoomRepository,
        IClassRoomConvertor classRoomConvertor,
        IClassRoomValidator validator,
        IBranchRepository branchRepository
    )
        : BaseService<
            IClassRoomRepository,
            ClassRoomDbo,
            IClassRoomConvertor,
            IClassRoomValidator,
            ClassRoomCreateDto,
            ClassRoomListDto,
            ClassRoomDetailDto,
            ClassRoomUpdateDto,
            ClassRoomFilter
        >(classRoomRepository, classRoomConvertor, validator),
            IClassRoomService
    {
        private readonly IOrganizationStudyHourRepository _organizationStudyHourRepository = organizationStudyHourRepository;
        private readonly IBranchRepository _branchRepository = branchRepository;

        public ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture)
        {
            ClassRoomTimeTableDto getClassRoomTimeTableDtos = new();
            List<CourseTermDateDbo> getClassRoomTimeTables = [.. _repository.GetEntity(false, x => x.Id == classRoomId).CourseTermDates];
            List<OrganizationStudyHourDbo> getStudyHours =
            [
                .. _organizationStudyHourRepository.GetEntities(false, x => x.OrganizationId == organizationId, null, x => x.Position).Result
            ];
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
                .ToList();
            List<CourseTermDateDbo> monday = getClassRoomTimeTables.Where(x => x.CourseTerm.Monday).ToList();
            List<CourseTermDateDbo> tuesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Tuesday).ToList();
            List<CourseTermDateDbo> wednesday = getClassRoomTimeTables.Where(x => x.CourseTerm.Wednesday).ToList();
            List<CourseTermDateDbo> thursday = getClassRoomTimeTables.Where(x => x.CourseTerm.Thursday).ToList();
            List<CourseTermDateDbo> friday = getClassRoomTimeTables.Where(x => x.CourseTerm.Friday).ToList();
            List<CourseTermDateDbo> saturday = getClassRoomTimeTables.Where(x => x.CourseTerm.Saturday).ToList();
            List<CourseTermDateDbo> sunday = getClassRoomTimeTables.Where(x => x.CourseTerm.Sunday).ToList();
            PrepareTimeTable(monday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_MONDAY, culture);
            PrepareTimeTable(tuesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_TUESDAY, culture);
            PrepareTimeTable(wednesday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_WEDNESDAY, culture);
            PrepareTimeTable(thursday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_THURSDAY, culture);
            PrepareTimeTable(friday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_FRIDAY, culture);
            PrepareTimeTable(saturday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SATURDAY, culture);
            PrepareTimeTable(sunday, getStudyHours, getClassRoomTimeTableDtos, Constants.TIME_TABLE_SUNDAY, culture);
            return getClassRoomTimeTableDtos;
        }

        private static void PrepareTimeTable(
            List<CourseTermDateDbo> day,
            List<OrganizationStudyHourDbo> getStudyHours,
            ClassRoomTimeTableDto timeTableItem,
            string dayName,
            string culture
        )
        {
            TimeTableDto timeTableDto = new() { DayOfWeek = dayName };
            foreach (OrganizationStudyHourDbo item in getStudyHours)
            {
                string courseName = "";
                courseName = day.FirstOrDefault(x => x.TimeFromId == item.ActiveFromId && x.TimeToId == item.ActiveToId)
                    ?.CourseTerm.Course.CourseTranslations.FindTranslation(culture)
                    .Name;
                timeTableDto.CourseTerm.Add(courseName);
            }
            timeTableItem.TimeTable.Add(timeTableDto);
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

        protected override Expression<Func<ClassRoomDbo, bool>> PrepareSqlFilter(ClassRoomFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(ClassRoomDbo), "classRoom");
            Expression expression = Expression.Constant(true);
            expression = FilterInt(filter.MaxCapacity, parameter, expression, nameof(ClassRoomDbo.MaxCapacity));
            expression = FilterInt(filter.Floor, parameter, expression, nameof(ClassRoomDbo.Floor));
            expression = FilterTranslation<ClassRoomTranslationDbo>(
                filter.Name,
                culture,
                parameter,
                expression,
                nameof(ClassRoomTranslationDbo.Name),
                nameof(ClassRoomTranslationDbo.Culture),
                nameof(ClassRoomDbo.ClassRoomTranslations)
            );
            return Expression.Lambda<Func<ClassRoomDbo, bool>>(expression, parameter);
        }

        public override Guid GetOrganizationIdByParentId(Guid objectId)
        {
            return _branchRepository.GetOrganizationId(objectId);
        }

        protected override Expression<Func<ClassRoomDbo, object>> PrepareSort(string columnName, string culture)
        {
            if (columnName == ClassRoomSort.Name.ToString())
            {
                ParameterExpression parameter = Expression.Parameter(typeof(ClassRoomDbo), "x");
                MemberExpression property = Expression.Property(parameter, nameof(ClassRoomDbo.ClassRoomTranslations));
                MethodCallExpression anyCall = Expression.Call(
                    typeof(Enumerable),
                    nameof(Enumerable.FirstOrDefault),
                    new Type[] { typeof(ClassRoomTranslationDbo) },
                    property
                );
                MemberExpression nameProperty = Expression.Property(anyCall, nameof(ClassRoomTranslationDbo.Name));
                Expression<Func<ClassRoomDbo, object>> lambda = Expression.Lambda<Func<ClassRoomDbo, object>>(
                    Expression.Convert(nameProperty, typeof(object)),
                    parameter
                );
                return lambda;
            }
            return base.PrepareSort(columnName, culture);
        }

        protected override bool IsChanged(ClassRoomDbo oldVersion, ClassRoomUpdateDto newVersion, string culture)
        {
            return oldVersion.MaxCapacity != newVersion.MaxCapacity
                || oldVersion.Floor != newVersion.Floor
                || oldVersion.ClassRoomTranslations.FindTranslation(culture).Name != newVersion.Name;
        }
    }
}
