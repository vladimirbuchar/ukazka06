using Core.Base.Convertor;
using Model.Edu.ClassRoom;
using Services.ClassRoom.Dto;

namespace Services.ClassRoom.Convertor
{
    public interface IClassRoomConvertor
        : IBaseConvertor<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto> { }
}
