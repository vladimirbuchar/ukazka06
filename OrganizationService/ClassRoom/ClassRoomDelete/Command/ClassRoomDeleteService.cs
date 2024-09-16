using Core.Base.Command.Delete;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.ClassRoom;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomDelete.Command
{
    public class ClassRoomDeleteService : BaseDeleteCommand<ClassRoomDbo, IClassRoomRepository>, IClassRoomDeleteService
    {
        public ClassRoomDeleteService(IClassRoomRepository repository)
            : base(repository) { }

        public override async Task<Result> Execute(Guid objectId, Guid userId)
        {
            ClassRoomDbo classRoomDbo = await _repository.GetEntity(objectId);
            if (classRoomDbo != null && classRoomDbo.IsOnline)
            {
                Result result = new();
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.CLASS_ROOM, MessageItem.CAN_NOT_DELETE));
                return result;
            }
            return await base.Execute(objectId, userId);
        }
    }
}
