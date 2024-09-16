using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Convertor
{
    public class ClassRoomCreateConvertor : IClassRoomCreateConvertor
    {
        public Task<ClassRoomDbo> ConvertToBussinessEntity(ClassRoomCreateDto create, string culture)
        {
            ClassRoomDbo classRoom =
                new()
                {
                    Floor = create.Floor,
                    MaxCapacity = create.MaxCapacity,
                    BranchId = create.BranchId,
                    IsOnline = create.IsOnline,
                    Name = create.Name
                };
            return Task.FromResult(classRoom);
        }
    }
}
