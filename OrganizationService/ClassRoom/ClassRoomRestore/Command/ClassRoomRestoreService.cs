using Core.Base.Command.Restore;
using Model.Edu.ClassRoom;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomRestore.Command
{
    public class ClassRoomRestoreService : BaseRestoreCommand<ClassRoomDbo, IClassRoomRepository>, IClassRoomRestoreService
    {
        public ClassRoomRestoreService(IClassRoomRepository repository)
            : base(repository) { }
    }
}
