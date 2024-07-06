using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using EduRepository.AnswerRepository;
using EduServices.Answer.Convertor;
using EduServices.Answer.Dto;
using EduServices.Answer.Validator;
using Model.CodeBook;
using Model.Edu.Answer;

namespace EduServices.Answer.Service
{
    public class AnswerService(
        IAnswerRepository answerRepository,
        IAnswerConvertor answerConvertor,
        IAnswerValidator answerValidator,
        IFileUploadRepository<AnswerFileRepositoryDbo> fileUploadRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository
    )
        : BaseService<IAnswerRepository, AnswerDbo, IAnswerConvertor, IAnswerValidator, AnswerCreateDto, AnswerListDto, AnswerDetailDto, AnswerUpdateDto, AnswerFileRepositoryDbo>(
            answerRepository,
            answerConvertor,
            answerValidator,
            fileUploadRepository,
            codeBookRepository
        ),
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
