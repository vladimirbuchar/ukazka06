using Core.Base.Command.DropDown;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomDropDown.Convertor;
using OrganizationService.ClassRoom.ClassRoomDropDown.Dto;
using Repository.Branch;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomDropDown.Service
{
    public class ClassRoomDropDownService : BaseDropDownCommand<ClassRoomDbo, IClassRoomRepository, ClassRoomDropDownDto, IClassRoomDropDownConvertor>, IClassRoomDropDownService
    {
        private readonly IBranchRepository _branchRepository;
        public ClassRoomDropDownService(IClassRoomRepository repository, IClassRoomDropDownConvertor convertor, IBranchRepository branchRepository) : base(repository, convertor)
        {
            _branchRepository = branchRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _branchRepository.GetOrganizationId(objectId);
        }
    }
}
