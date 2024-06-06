using Core.Base.Convertor;
using EduServices.ClassRoom.Dto;
using Model.Tables.Edu.ClassRoom;

namespace EduServices.ClassRoom.Convertor
{
    public interface IClassRoomConvertor : IBaseConvertor<ClassRoomDbo, ClassRoomCreateDto, ClassRoomListDto, ClassRoomDetailDto, ClassRoomUpdateDto> { }
}
