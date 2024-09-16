using Core.Base.Command.Update;
using Core.DataTypes;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Convertor;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Dto;
using CourseMaterialService.CourseLesson.CourseTestUpdate.Validator;
using Model.Edu.CourseTest;
using Model.Link;
using Repository.CourseTestBankOfQuestion;
using Repository.Test;

namespace CourseMaterialService.CourseLesson.CourseTestUpdate.Command
{
    public class CourseTestUpdateService
        : BaseUpdateCommand<CourseTestDbo, ITestRepository, CourseTestUpdateDto, ICourseTestUpdateConvertor, ICourseTestUpdateValidator>,
            ICourseTestUpdateService
    {
        private readonly ICourseTestBankOfQuestionRepository _courseTestBankOfQuestionRepository;

        public CourseTestUpdateService(
            ICourseTestBankOfQuestionRepository courseTestBankOfQuestionRepository,
            ITestRepository repository,
            ICourseTestUpdateConvertor convertor,
            ICourseTestUpdateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _courseTestBankOfQuestionRepository = courseTestBankOfQuestionRepository;
        }

        public override async Task<Result> Execute(CourseTestUpdateDto update, Guid userId, string culture, Result? result = null)
        {
            CourseTestDbo test = await _repository.GetEntity(false, x => x.CourseLessonId == update.CourseLessonId);
            update.Id = test.Id;
            foreach (CourseTestBankOfQuestionDbo item in test.CourseTestBankOfQuestions)
            {
                if (!update.BankOfQuestion.Contains(item.BankOfQuestionId))
                {
                    await _courseTestBankOfQuestionRepository.DeleteEntity(item.Id, Guid.Empty);
                }
            }
            foreach (Guid bankOfQuestionId in update.BankOfQuestion)
            {
                if (!test.CourseTestBankOfQuestions.Select(x => x.BankOfQuestionId).Contains(bankOfQuestionId))
                {
                    _ = await _courseTestBankOfQuestionRepository.CreateEntity(
                        new CourseTestBankOfQuestionDbo() { CourseTestId = test.Id, BankOfQuestionId = bankOfQuestionId },
                        Guid.Empty
                    );
                }
            }
            return await base.Execute(update, userId, culture, result);
        }
    }
}
