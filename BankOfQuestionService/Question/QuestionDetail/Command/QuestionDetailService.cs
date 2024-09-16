using BankOfQuestionService.Question.QuestionDetail.Convertor;
using BankOfQuestionService.Question.QuestionDetail.Dto;
using Core.Base.Command.Detail;
using Model.Edu.Question;
using Repository.Question;

namespace BankOfQuestionService.Question.QuestionDetail.Command
{
    public class QuestionDetailService
        : BaseDetailCommand<QuestionDbo, IQuestionRepository, QuestionDetailDto, IQuestionDetailConvertor>,
            IQuestionDetailService
    {
        public QuestionDetailService(IQuestionRepository repository, IQuestionDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
