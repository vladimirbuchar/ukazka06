using Core.Base.Validator;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Validator
{
    public interface IClassRoomCreateValidator : IBaseCreateValidator<ClassRoomDbo, ClassRoomCreateDto> { }
}
