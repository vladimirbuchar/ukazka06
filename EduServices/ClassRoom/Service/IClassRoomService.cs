using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.ClassRoom.Dto;
using Model.Tables.Edu.ClassRoom;

namespace EduServices.ClassRoom.Service
{
    public interface IClassRoomService : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto>
    {
        HashSet<ClassRoomListDto> GetAllClassRoomInOrganization(Guid organizationId, string culture = "");
        ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
