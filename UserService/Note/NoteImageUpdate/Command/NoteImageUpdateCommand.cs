using Core.Base.Command.Update;
using Core.DataTypes;
using Integration.ImagePng;
using Model.Edu.Note;
using Repository.Note;
using UserService.Note.NoteImageUpdate.Convertor;
using UserService.Note.NoteImageUpdate.Dto;
using UserService.Note.NoteImageUpdate.Validator;

namespace UserService.Note.NoteImageUpdate.Command
{
    public class NoteImageUpdateCommand : BaseUpdateCommand<NoteDbo, INoteRepository, NoteImageUpdateDto, INoteImageUpdateConvertor, INoteImageUpdateValidator>, INoteImageUpdateCommand
    {
        private readonly IImagePngIntegration _imagePng;
        public NoteImageUpdateCommand(IImagePngIntegration imagePng, INoteRepository repository, INoteImageUpdateConvertor convertor, INoteImageUpdateValidator validator) : base(repository, convertor, validator)
        {
            _imagePng = imagePng;
        }
        public override async Task<Result> Execute(NoteImageUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            Guid fileName = _imagePng.SaveFilePngFile(update.Img, "note");
            update.FileName = fileName;
            return await base.Execute(update, userId, culture, result);
        }


    }
}
