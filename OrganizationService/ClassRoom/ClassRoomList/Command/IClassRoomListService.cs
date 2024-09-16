using Core.Base.Command.List;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomList.Dto;
using OrganizationService.ClassRoom.ClassRoomList.Filter;

namespace OrganizationService.ClassRoom.ClassRoomList.Command
{
    public interface IClassRoomListService : IBaseListCommand<ClassRoomDbo, ClassRoomListDto, ClassRoomFilter> { }
}
