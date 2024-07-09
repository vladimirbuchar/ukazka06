using System;
using Core.Base.Service;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;
using Services.ClassRoom.Filter;

namespace Services.ClassRoom.Service
{
    public interface IClassRoomService
        : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto, ClassRoomFilter>
    {
        ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
