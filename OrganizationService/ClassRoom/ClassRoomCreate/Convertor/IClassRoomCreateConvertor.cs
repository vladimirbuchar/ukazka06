using Core.Base.Convertor;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Convertor
{
    public interface IClassRoomCreateConvertor : IBaseCreateConvertor<ClassRoomDbo, ClassRoomCreateDto> { }
}
