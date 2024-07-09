using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Request;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Answer;
using Repository.AnswerRepository;
using Services.Answer.Convertor;
using Services.Answer.Dto;
using Services.Answer.Validator;

namespace Services.Answer.Service
{
    public class AnswerService(
        IAnswerRepository answerRepository,
        IAnswerConvertor answerConvertor,
        IAnswerValidator answerValidator,
        IFileUploadRepository<AnswerFileRepositoryDbo> fileUploadRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository
    )
        : BaseService<
            IAnswerRepository,
            AnswerDbo,
            IAnswerConvertor,
            IAnswerValidator,
            AnswerCreateDto,
            AnswerListDto,
            AnswerDetailDto,
            AnswerUpdateDto,
            AnswerFileRepositoryDbo,
            FilterRequest
        >(answerRepository, answerConvertor, answerValidator, fileUploadRepository, codeBookRepository),
            IAnswerService
    {
        protected override bool IsChanged(AnswerDbo oldVersion, AnswerUpdateDto newVersion, string culture)
        {
            return oldVersion.TestQuestionAnswerTranslations.FindTranslation(culture, true)?.Answer != newVersion.AnswerText
                || newVersion.IsTrueAnswer != oldVersion.IsTrueAnswer
                || newVersion.FileId != oldVersion.AnswerFileRepository.FindTranslation(culture, true)?.Id;
        }
    }
}
