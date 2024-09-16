using Core.Base.Command.Detail;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDetail.Dto;

namespace OrganizationService.ClassRoom.ClassRoomDetail.Command
{
    public interface IClassRoomDetailService : IBaseDetailCommand<ClassRoomDbo, ClassRoomDetailDto> { }
}
