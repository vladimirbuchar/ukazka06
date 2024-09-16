using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDetail.Dto;
using OrganizationService.ClassRoom.ClassRoomUpdate.Dto;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomUpdate.Validator
{
    public class ClassRoomUpdateValidator : BaseUpdateValidator<ClassRoomDbo, IClassRoomRepository, ClassRoomUpdateDto>, IClassRoomUpdateValidator
    {
        public ClassRoomUpdateValidator(IClassRoomRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(ClassRoomUpdateDto update)
        {
            Result<ClassRoomDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.CLASS_ROOM, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.MaxCapacity, result, MessageCategory.CLASS_ROOM, Constants.CLASS_ROOM_MAX_CAPACITY_IS_LESS_THEN_ZERO);
            return await Task.FromResult(result);
        }
    }
}
