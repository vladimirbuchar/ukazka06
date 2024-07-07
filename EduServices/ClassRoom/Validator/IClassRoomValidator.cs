using Core.Base.Validator;
using Model.Edu.ClassRoom;
using Repository.ClassRoomRepository;
using Services.ClassRoom.Dto;

namespace Services.ClassRoom.Validator
{
    public interface IClassRoomValidator : IBaseValidator<ClassRoomDbo, IClassRoomRepository, ClassRoomCreateDto, ClassRoomDetailDto, ClassRoomUpdateDto> { }
}
