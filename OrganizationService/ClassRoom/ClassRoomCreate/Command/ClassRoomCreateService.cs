using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomCreate.Convertor;
using OrganizationService.ClassRoom.ClassRoomCreate.Dto;
using OrganizationService.ClassRoom.ClassRoomCreate.Validator;
using Repository.Branch;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomCreate.Command
{
    public class ClassRoomCreateService
        : BaseCreateCommand<ClassRoomDbo, IClassRoomRepository, ClassRoomCreateDto, IClassRoomCreateConvertor, IClassRoomCreateValidator>,
            IClassRoomCreateService
    {
        private readonly IBranchRepository _branchRepository;

        public ClassRoomCreateService(
            IBranchRepository branchRepository,
            IClassRoomRepository repository,
            IClassRoomCreateConvertor convertor,
            IClassRoomCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture)
        {
            _branchRepository = branchRepository;
        }

        public override async Task<Guid> GetOrganizationIdByParentId(Guid objectId)
        {
            return await _branchRepository.GetOrganizationId(objectId);
        }
    }
}
