using Core.Base.Command.Detail;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDetail.Convertor;
using OrganizationService.ClassRoom.ClassRoomDetail.Dto;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomDetail.Command
{
    public class ClassRoomDetailService
        : BaseDetailCommand<ClassRoomDbo, IClassRoomRepository, ClassRoomDetailDto, IClassRoomDetailConvertor>,
            IClassRoomDetailService
    {
        public ClassRoomDetailService(IClassRoomRepository repository, IClassRoomDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
