using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionFileUpload.Command
{
    public class QuestionFileUploadFileUploadService : BaseServiceCommand<QuestionFileRepositoryDbo>, IQuestionFileUploadFileUploadService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionFileUploadFileUploadService(
            IQuestionRepository questionRepository,
            IFileUploadRepository<QuestionFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _questionRepository.GetOrganizationId(objectId);
        }
    }
}
