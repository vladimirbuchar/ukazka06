using Core.Base.Command.DropDown;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDropDown.Dto;

namespace OrganizationService.ClassRoom.ClassRoomDropDown.Service
{
    public interface IClassRoomDropDownService : IBaseDropDownCommand<ClassRoomDbo, ClassRoomDropDownDto>
    {
    }
}