using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using EduRepository.QuestionRepository;
using EduServices.Question.Convertor;
using EduServices.Question.Dto;
using EduServices.Question.Validator;
using Model.Tables.CodeBook;
using Model.Tables.Edu.TestQuestion;

namespace EduServices.Question.Service
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
            IQuestionService
    { }
}
