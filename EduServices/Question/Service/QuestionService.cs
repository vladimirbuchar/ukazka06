using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Question;
using Repository.QuestionRepository;
using Services.Question.Convertor;
using Services.Question.Dto;
using Services.Question.Validator;

namespace Services.Question.Service
{
    public class QuestionService(
        IQuestionRepository questionRepository,
        IQuestionConvertor questionConvertor,
        IQuestionValidator validator,
        IFileUploadRepository<QuestionFileRepositoryDbo> fileRepository,
        ICodeBookRepository<CultureDbo> codeBookRepository
    )
        : BaseService<IQuestionRepository, QuestionDbo, IQuestionConvertor, IQuestionValidator, QuestionCreateDto, QuestionListDto, QuestionDetailDto, QuestionUpdateDto, QuestionFileRepositoryDbo>(
            questionRepository,
            questionConvertor,
            validator,
            fileRepository,
            codeBookRepository
        ),
            IQuestionService { }
}
