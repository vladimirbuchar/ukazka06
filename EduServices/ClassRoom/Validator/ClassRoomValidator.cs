using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.BranchRepository;
using EduRepository.ClassRoomRepository;
using EduServices.ClassRoom.Dto;
using Model.Edu.ClassRoom;

namespace EduServices.ClassRoom.Validator
{
    public class ClassRoomValidator(IClassRoomRepository repository, IBranchRepository branchRepository)
        : BaseValidator<ClassRoomDbo, IClassRoomRepository, ClassRoomCreateDto, ClassRoomDetailDto, ClassRoomUpdateDto>(repository),
            IClassRoomValidator
    {
        private readonly IBranchRepository _branchRepository = branchRepository;

        public override Result<ClassRoomDetailDto> IsValid(ClassRoomCreateDto create)
        {
            Result<ClassRoomDetailDto> result = new();
            IsValidString(create.Name, result, Category.CLASS_ROOM, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.MaxCapacity, result, Category.CLASS_ROOM, Constants.CLASS_ROOM_MAX_CAPACITY_IS_LESS_THEN_ZERO);
            if (_branchRepository.GetEntity(create.BranchId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.BRANCH, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<ClassRoomDetailDto> IsValid(ClassRoomUpdateDto update)
        {
            Result<ClassRoomDetailDto> result = new();
            IsValidString(update.Name, result, Category.CLASS_ROOM, GlobalValue.STRING_IS_EMPTY);
            IsValidPostiveNumber(update.MaxCapacity, result, Category.CLASS_ROOM, Constants.CLASS_ROOM_MAX_CAPACITY_IS_LESS_THEN_ZERO);
            return result;
        }
    }
}
