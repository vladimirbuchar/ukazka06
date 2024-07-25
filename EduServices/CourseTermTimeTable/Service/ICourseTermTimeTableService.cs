using Core.Base.Service;
using Core.DataTypes;
using Services.CourseTermTimeTable.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CourseTermTimeTable.Service
{
    public interface ICourseTermTimeTableService : IBaseService
    {
        Task<Result> GenerateTimeTable(
            DateTime activeFrom,
            DateTime activeTo,
            Guid timeFromId,
            Guid timeToId,
            List<bool> days,
            Guid courseTermId,
            List<string> lectors,
            Guid classRoomId
        );
        Task<List<CourseTermTimeTableListDto>> GetTimeTable(Guid courseTermId, string culture);
        Task<Result> CancelCourseTerm(Guid courseTermTimeTableId);
        Task<Result> Restore(Guid courseTermTimeTableId);
        Task<Result> GenerateTimeTable(Guid courseTermId);
    }
}
