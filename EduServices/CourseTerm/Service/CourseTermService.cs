using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.ClassRoom;
using Model.Edu.CourseTerm;
using Model.Edu.OrganizationStudyHour;
using Model.Link;
using Repository.ClassRoomRepository;
using Repository.CourseLectorRepository;
using Repository.CourseRepository;
using Repository.CourseTermRepository;
using Repository.OrganizationHoursRepository;
using Repository.StudentInGroupCourseTerm;
using Services.CourseTerm.Convertor;
using Services.CourseTerm.Dto;
using Services.CourseTerm.Filter;
using Services.CourseTerm.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.CourseTerm.Service
{
   
    public class CourseTermService(
        IStudentInGroupCourseTermRepository studentInGroupCourseTermRepository,
        ICourseLectorRepository courseLectorRepository,
        IOrganizationStudyHourRepository organizationStudyHoursRepository,
        ICourseTermRepository courseTermRepository,
        ICourseTermConvertor courseTermConvertor,
        IClassRoomRepository classRoomRepository,
        ICourseRepository courseRepository,
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
            CourseTermFilter
        >(courseTermRepository, courseTermConvertor, validator),
            ICourseTermService
    {
        private readonly IClassRoomRepository _classRoomRepository = classRoomRepository;
        private readonly IOrganizationStudyHourRepository _organizationStudyHoursRepository = organizationStudyHoursRepository;
        private readonly ICourseLectorRepository _courseLectorRepository = courseLectorRepository;
        private readonly IStudentInGroupCourseTermRepository _studentInGroupCourseTermRepository = studentInGroupCourseTermRepository;
        private readonly ICourseRepository _courseRepository = courseRepository;

        public override async Task<Result> AddObject(CourseTermCreateDto addObject, Guid userId, string culture)
        {
            if (addObject.ClassRoomId == null)
            {
                addObject.ClassRoomId = (await _classRoomRepository
                    .GetEntity(false, x => x.IsOnline == true && x.Branch.OrganizationId == addObject.OrganizationId))
                    .Id;
            }
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                CourseTermDbo addCourseTerm = await _convertor.ConvertToBussinessEntity(addObject, culture);
                if (addCourseTerm.OrganizationStudyHourId != null)
                {
                    List<OrganizationStudyHourDbo> getOrganizationSetting = await _organizationStudyHoursRepository
                        .GetEntities(false, x => x.OrganizationId == addObject.OrganizationId);
                    if (getOrganizationSetting.Count > 0)
                    {
                        addCourseTerm.TimeFromId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveFromId;
                        addCourseTerm.TimeToId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveToId;
                    }
                }

                CourseTermDbo entity = await _repository.CreateEntity(addCourseTerm, userId);
                foreach (Guid item in addObject.Lector)
                {
                    _ = await _courseLectorRepository.CreateEntity(
                        new CourseLectorDbo() { CourseTermId = entity.Id, UserInOrganizationId = item },
                        userId
                    );
                }
                foreach (Guid item in addObject.StudentGroup)
                {
                    _ = await _studentInGroupCourseTermRepository.CreateEntity(
                        new StudentInGroupCourseTermDbo() { CourseTermId = entity.Id, StudentGroupId = item },
                        userId
                    );
                }
                return new Result<CourseTermDetailDto>() { Data = await _convertor.ConvertToWebModel(entity, culture) };
            }
            return result;
        }
        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _courseRepository.GetOrganizationId(objectId);
        }

        public override async Task<Result<CourseTermDetailDto>> UpdateObject(CourseTermUpdateDto update, Guid userId, string culture, Result<CourseTermDetailDto> result = null)
        {
            if (update.ClassRoomId == null)
            {
                update.ClassRoomId = (await _classRoomRepository
                    .GetEntity(false, x => x.IsOnline == true && x.Branch.OrganizationId == update.OrganizationId))
                    .Id;
            }
            result = await _validator.IsValid(update);
            if (result.IsOk)
            {
                CourseTermDbo entity = await _repository.GetEntity(update.Id);
                CourseTermDbo addCourseTerm = await _convertor.ConvertToBussinessEntity(update, entity, culture);
                if (addCourseTerm.OrganizationStudyHourId != null)
                {
                    List<OrganizationStudyHourDbo> getOrganizationSetting = await _organizationStudyHoursRepository
                        .GetEntities(false, x => x.OrganizationId == update.OrganizationId);
                    if (getOrganizationSetting.Count() > 0)
                    {
                        addCourseTerm.TimeFromId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveFromId;
                        addCourseTerm.TimeToId = getOrganizationSetting.FirstOrDefault(x => x.Id == addCourseTerm.OrganizationStudyHourId).ActiveToId;
                    }
                }

                List<CourseLectorDbo> lectors = await _courseLectorRepository.GetEntities(false, x => x.CourseTermId == entity.Id);
                foreach (CourseLectorDbo lector in lectors)
                {
                    await _courseLectorRepository.DeleteEntity(lector.Id, userId);
                }

                foreach (Guid item in update.Lector)
                {

                    _ = await _courseLectorRepository.CreateEntity(
                        new CourseLectorDbo() { CourseTermId = entity.Id, UserInOrganizationId = item },
                        userId
                    );
                }
                List<StudentInGroupCourseTermDbo> studentGroups = await _studentInGroupCourseTermRepository.GetEntities(false, x => x.CourseTermId == entity.Id);
                foreach (StudentInGroupCourseTermDbo studentGroup in studentGroups)
                {
                    await _studentInGroupCourseTermRepository.DeleteEntity(studentGroup.Id, userId);
                }

                foreach (Guid item in update.StudentGroup)
                {
                    _ = await _studentInGroupCourseTermRepository.CreateEntity(
                        new StudentInGroupCourseTermDbo() { CourseTermId = entity.Id, StudentGroupId = item },
                        userId
                    );
                }
                return new Result<CourseTermDetailDto>() { Data = await _convertor.ConvertToWebModel(entity, culture) };
            }
            return result;
        }

        protected override Expression<Func<CourseTermDbo, bool>> PrepareSqlFilter(CourseTermFilter filter, string culture)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(CourseTermDbo), "courseTerm");
            Expression expression = Expression.Constant(true); // Start with a true expression
            expression = FilterBool(filter.Monday, parameter, expression, nameof(CourseTermDbo.Monday));
            expression = FilterBool(filter.Thursday, parameter, expression, nameof(CourseTermDbo.Thursday));
            expression = FilterBool(filter.Wednesday, parameter, expression, nameof(CourseTermDbo.Wednesday));
            expression = FilterBool(filter.Tuesday, parameter, expression, nameof(CourseTermDbo.Tuesday));
            expression = FilterBool(filter.Friday, parameter, expression, nameof(CourseTermDbo.Friday));
            expression = FilterBool(filter.Saturday, parameter, expression, nameof(CourseTermDbo.Saturday));
            expression = FilterBool(filter.Sunday, parameter, expression, nameof(CourseTermDbo.Sunday));
            expression = FilterGuid(filter.ClassRoomId, parameter, expression, nameof(CourseTermDbo.ClassRoomId));
            expression = FilterGuid(filter.BranchId, parameter, expression, nameof(CourseTermDbo.ClassRoom), nameof(ClassRoomDbo.BranchId));
            expression = FilterDate(filter.ActiveFrom.HasValue ? filter.ActiveFrom.Value : null, filter.ActiveTo.HasValue ? filter.ActiveTo.Value : DateTime.MaxValue, parameter, expression, nameof(CourseTermDbo.ActiveFrom), nameof(CourseTermDbo.ActiveTo));
            return Expression.Lambda<Func<CourseTermDbo, bool>>(expression, parameter);
        }
    }
}
