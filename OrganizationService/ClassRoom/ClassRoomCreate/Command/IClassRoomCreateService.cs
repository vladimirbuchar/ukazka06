using Core.Base.Command.Create;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Command
{
    public interface IClassRoomCreateService : IBaseCreateCommand<ClassRoomDbo, ClassRoomCreateDto> { }
}
