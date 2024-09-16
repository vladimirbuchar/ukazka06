using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;
using Repository.Branch;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Validator
{
    public class ClassRoomCreateValidator : BaseCreateValidator<ClassRoomDbo, IClassRoomRepository, ClassRoomCreateDto>, IClassRoomCreateValidator
    {
        private readonly IBranchRepository _branchRepository;

        public ClassRoomCreateValidator(IClassRoomRepository repository, IBranchRepository branchRepository)
            : base(repository)
        {
            _branchRepository = branchRepository;
        }

        public override async Task<ResultInsert> IsValid(ClassRoomCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.CLASS_ROOM, MessageItem.STRING_IS_EMPTY);
            IsValidPostiveNumber(create.MaxCapacity, result, MessageCategory.CLASS_ROOM, Constants.CLASS_ROOM_MAX_CAPACITY_IS_LESS_THEN_ZERO);
            if (await _branchRepository.GetEntity(create.BranchId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.BRANCH, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
