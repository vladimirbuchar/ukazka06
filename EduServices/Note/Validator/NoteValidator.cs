using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Note;
using Repository.CourseRepository;
using Repository.NoteRepository;
using Repository.UserRepository;
using Services.Note.Dto;
using System.Threading.Tasks;

namespace Services.Note.Validator
{
    public class NoteValidator(
        INoteRepository repository,
        ICodeBookRepository<NoteTypeDbo> noteType,
        ICourseRepository courseRepository,
        IUserRepository userRepository
    ) : BaseValidator<NoteDbo, INoteRepository, NoteCreateDto, NoteDetailDto, NoteUpdateDto>(repository), INoteValidator
    {
        private readonly ICodeBookRepository<NoteTypeDbo> _noteType = noteType;
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public override async Task<Result> IsValid(NoteCreateDto create)
        {
            Result<NoteDetailDto> result = new();
            if (await _noteType.GetEntity(false, x => x.Id == create.NoteTypeId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.NOTE, Constants.NOTE_TYPE_NOT_EXISTS));
            }
            if (await _courseRepository.GetEntity(create.CourseId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE, MessageItem.NOT_EXISTS));
            }
            if (await _userRepository.GetEntity(create.UserId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.NOT_EXISTS));
            }
            return result;
        }
    }
}
