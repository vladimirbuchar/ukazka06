using Core.Base.Command.Update;
using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.ClassRoom;
using OrganizationService.ClassRoom.ClassRoomUpdate.Convertor;
using OrganizationService.ClassRoom.ClassRoomUpdate.Dto;
using OrganizationService.ClassRoom.ClassRoomUpdate.Validator;
using Repository.ClassRoom;

namespace OrganizationService.ClassRoom.ClassRoomUpdate.Command
{
    public class ClassRoomUpdateService
        : BaseUpdateCommand<ClassRoomDbo, IClassRoomRepository, ClassRoomUpdateDto, IClassRoomUpdateConvertor, IClassRoomUpdateValidator>,
            IClassRoomUpdateService
    {
        public ClassRoomUpdateService(
            IClassRoomRepository repository,
            IClassRoomUpdateConvertor convertor,
            IClassRoomUpdateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }

        protected override bool IsChanged(ClassRoomDbo oldVersion, ClassRoomUpdateDto newVersion, string culture)
        {
            return oldVersion.MaxCapacity != newVersion.MaxCapacity || oldVersion.Floor != newVersion.Floor || oldVersion.Name != newVersion.Name;
        }
    }
}
