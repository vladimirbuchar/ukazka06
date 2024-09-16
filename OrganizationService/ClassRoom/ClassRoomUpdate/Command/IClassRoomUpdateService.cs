using Core.Base.Command.Update;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomUpdate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomUpdate.Command
{
    public interface IClassRoomUpdateService : IBaseUpdateCommand<ClassRoomDbo, ClassRoomUpdateDto> { }
}
