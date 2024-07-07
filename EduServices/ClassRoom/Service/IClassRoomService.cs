using System;
using Core.Base.Service;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;

namespace Services.ClassRoom.Service
{
    public interface IClassRoomService : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto>
    {
        ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
