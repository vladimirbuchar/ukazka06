using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using EduRepository.QuestionRepository;
using EduServices.Question.Convertor;
using EduServices.Question.Dto;
using EduServices.Question.Validator;
using Model.CodeBook;
using Model.Edu.Question;

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
