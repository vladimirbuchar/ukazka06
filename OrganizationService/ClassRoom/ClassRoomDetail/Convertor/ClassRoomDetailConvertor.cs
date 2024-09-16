using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDetail.Dto;

namespace OrganizationService.ClassRoom.ClassRoomDetail.Convertor
{
    public class ClassRoomDetailConvertor : IClassRoomDetailConvertor
    {
        public Task<ClassRoomDetailDto> ConvertToWebModel(ClassRoomDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new ClassRoomDetailDto()
                {
                    Floor = detail.Floor,
                    Id = detail.Id,
                    MaxCapacity = detail.MaxCapacity,
                    Name = detail.Name
                }
            );
        }
    }
}
