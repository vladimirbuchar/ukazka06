using System;
using System.Collections.Generic;
using Core.Base.Repository;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.CourseTermDate;

namespace EduRepository.ClassRoomRepository
{
    public interface IClassRoomRepository : IBaseRepository<ClassRoomDbo>
    {
        HashSet<CourseTermDateDbo> GetClassRoomTimeTable(Guid classRoomId);
        ClassRoomDbo GetOnlineClassRoom(Guid organizationId);
    }
}
