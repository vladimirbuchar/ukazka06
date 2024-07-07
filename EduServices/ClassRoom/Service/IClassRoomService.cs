using Core.Base.Service;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;
using System;

namespace Services.ClassRoom.Service
{
    public interface IClassRoomService : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto>
    {

        ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
