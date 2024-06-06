using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.CourseTermTimeTable.Dto;

namespace EduServices.CourseTermTimeTable.Service
{
    public interface ICourseTermTimeTableService : IBaseService
    {
        void GenerateTimeTable(DateTime activeFrom, DateTime activeTo, Guid timeFromId, Guid timeToId, List<bool> days, Guid courseTermId, List<string> lectors, Guid classRoomId);
        HashSet<CourseTermTimeTableListDto> GetTimeTable(Guid courseTermId, string culture);
        void CancelCourseTerm(Guid courseTermTimeTableId);
        void Restore(Guid courseTermTimeTableId);
        void GenerateTimeTable(Guid courseTermId);
    }
}
