using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.Answer;
using Repository.Answer;

namespace BankOfQuestionService.Answer.AnswerFileUpload.Command
{
    public class AnswerFileUploadCommand : BaseServiceCommand<AnswerFileRepositoryDbo>, IAnswerFileUploadCommand
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerFileUploadCommand(
            IAnswerRepository answerRepository,
            IFileUploadRepository<AnswerFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository)
        {
            _answerRepository = answerRepository;
        }

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _answerRepository.GetOrganizationId(objectId);
        }
    }
}
