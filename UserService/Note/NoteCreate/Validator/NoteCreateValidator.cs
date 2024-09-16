using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.CodeBook;
using Model.Edu.Note;
using Repository.Course;
using Repository.Note;
using Repository.User;
using UserService.Note.NoteCreate.Dto;

namespace UserService.Note.NoteCreate.Validator
{
    public class NoteCreateValidator : BaseCreateValidator<NoteDbo, INoteRepository, NoteCreateDto>, INoteCreateValidator
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICodeBookRepository<NoteTypeDbo> _noteType;
        public NoteCreateValidator(INoteRepository repository, ICourseRepository courseRepository, IUserRepository userRepository, ICodeBookRepository<NoteTypeDbo> noteType) : base(repository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _noteType = noteType;
        }

        public override async Task<ResultInsert> IsValid(NoteCreateDto create)
        {
            ResultInsert result = new();
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
