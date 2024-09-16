using Core.Base.Validator;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomUpdate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomUpdate.Validator
{
    public interface IClassRoomUpdateValidator : IBaseUpdateValidator<ClassRoomDbo, ClassRoomUpdateDto> { }
}
