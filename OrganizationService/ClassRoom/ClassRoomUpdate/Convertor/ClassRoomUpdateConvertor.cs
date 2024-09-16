using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomUpdate.Dto;

namespace OrganizationService.ClassRoom.ClassRoomUpdate.Convertor
{
    public class ClassRoomUpdateConvertor : IClassRoomUpdateConvertor
    {
        public Task<ClassRoomDbo> ConvertToBussinessEntity(ClassRoomUpdateDto update, ClassRoomDbo entity, string culture)
        {
            entity.Name = update.Name;
            entity.Floor = update.Floor;
            entity.MaxCapacity = update.MaxCapacity;
            return Task.FromResult(entity);
        }
    }
}
