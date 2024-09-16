using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDropDown.Dto;

namespace OrganizationService.ClassRoom.ClassRoomDropDown.Convertor
{
    public class ClassRoomDropDownConvertor : IClassRoomDropDownConvertor
    {
        public Task<List<ClassRoomDropDownDto>> ConvertToWebModel(List<ClassRoomDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new ClassRoomDropDownDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList());
        }
    }
}
