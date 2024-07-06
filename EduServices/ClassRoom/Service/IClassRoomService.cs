using Core.Base.Service;
using EduServices.ClassRoom.Dto;
using Model.Edu.ClassRoom;
using System;

namespace EduServices.ClassRoom.Service
{
    public interface IClassRoomService : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto>
    {

        ClassRoomTimeTableDto GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
