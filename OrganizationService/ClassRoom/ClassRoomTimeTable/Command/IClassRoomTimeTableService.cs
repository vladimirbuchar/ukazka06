using OrganizationService.ClassRoom.ClassRoomTimeTable.Dto;

namespace OrganizationService.ClassRoom.ClassRoomTimeTable.Command
{
    public interface IClassRoomTimeTableService
    {
        Task<ClassRoomTimeTableDto> Execute(Guid classRoomId, Guid organizationId, List<string> culture);
        Task<Guid> GetOrganizationIdByObjectId(Guid objectId);
    }
}
