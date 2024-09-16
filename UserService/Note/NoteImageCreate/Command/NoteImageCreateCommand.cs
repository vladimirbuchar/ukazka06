using Core.Base.Command.Create;
using Core.DataTypes;
using Integration.ImagePng;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteImageCreate.Convertor;
using UserService.Note.NoteImageCreate.Dto;
using UserService.Note.NoteImageCreate.Validator;

namespace UserService.Note.NoteImageCreate.Command
{
    public class NoteImageCreateCommand : BaseCreateCommand<NoteDbo, INoteRepository, NoteImageCreateDto, INoteImageCreateConvertor, INoteImageCreateValidator>, INoteImageCreateCommand
    {
        private readonly IImagePngIntegration _image;
        public NoteImageCreateCommand(IImagePngIntegration image, INoteRepository repository, INoteImageCreateConvertor convertor, INoteImageCreateValidator validator) : base(repository, convertor, validator)
        {
            _image = image;
        }
        public override async Task<ResultInsert> Execute(NoteImageCreateDto addObject, Guid userId, string culture)
        {
            addObject.UserId = userId;
            addObject.FileName = _image.SaveFilePngFile(addObject.Img, "note");
            return await base.Execute(addObject, userId, culture);
        }
    }
}
