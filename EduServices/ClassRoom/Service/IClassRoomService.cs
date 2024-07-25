using Core.Base.Service;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;
using Services.ClassRoom.Filter;
using System;
using System.Threading.Tasks;

namespace Services.ClassRoom.Service
{
    public interface IClassRoomService
        : IBaseService<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto, ClassRoomFilter>
    {
        Task<ClassRoomTimeTableDto> GetClassRoomTimeTable(Guid classRoomId, Guid organizationId, string culture);
    }
}
