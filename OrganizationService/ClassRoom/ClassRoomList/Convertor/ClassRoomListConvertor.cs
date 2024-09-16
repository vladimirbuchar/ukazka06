using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomList.Dto;

namespace OrganizationService.ClassRoom.ClassRoomList.Convertor
{
    public class ClassRoomListConvertor : IClassRoomListConvertor
    {
        public Task<List<ClassRoomListDto>> ConvertToWebModel(List<ClassRoomDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new ClassRoomListDto()
                {
                    Floor = item.Floor,
                    Id = item.Id,
                    MaxCapacity = item.MaxCapacity,
                    Name = item.Name
                })
                    .ToList()
            );
        }
    }
}
