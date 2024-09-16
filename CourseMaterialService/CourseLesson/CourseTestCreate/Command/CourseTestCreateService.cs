using Core.Base.Command.Create;
using Core.DataTypes;
using CourseMaterialService.CourseLesson.CourseTestCreate.Convertor;
using CourseMaterialService.CourseLesson.CourseTestCreate.Dto;
using CourseMaterialService.CourseLesson.CourseTestCreate.Validator;
using Model.Edu.CourseLesson;
using Model.Edu.CourseTest;
using Model.Link;
using Repository.CourseLesson;
using Repository.CourseTestBankOfQuestion;
using Repository.Test;

namespace CourseMaterialService.CourseLesson.CourseTestCreate.Command
{
    public class CourseTestCreateService
        : BaseCreateCommand<CourseTestDbo, ITestRepository, CourseTestCreateDto, ICourseTestCreateConvertor, ICourseTestCreateValidator>,
            ICourseTestCreateService
    {
        private readonly ICourseTestBankOfQuestionRepository _courseTestBankOfQuestionRepository;
        private readonly ICourseLessonRepository _courseLessonRepository;

        public CourseTestCreateService(
            ICourseLessonRepository courseLessonRepository,
            ICourseTestBankOfQuestionRepository courseTestBankOfQuestionRepository,
            ITestRepository repository,
            ICourseTestCreateConvertor convertor,
            ICourseTestCreateValidator validator
        )
            : base(repository, convertor, validator)
        {
            _courseTestBankOfQuestionRepository = courseTestBankOfQuestionRepository;
            _courseLessonRepository = courseLessonRepository;
        }

        public override async Task<ResultInsert> Execute(CourseTestCreateDto addObject, Guid userId, string culture)
        {
            ResultInsert result = await base.Execute(addObject, userId, culture);
            if (result.IsOk)
            {
                CourseLessonDbo courseLesson = await _courseLessonRepository.GetEntity(addObject.CourseLessonId);
                courseLesson.CourseTestId = result.InsertedId;
                _ = await _courseLessonRepository.UpdateEntity(courseLesson, userId);
                foreach (Guid bankOfQuestionId in addObject.BankOfQuestion)
                {
                    _ = await _courseTestBankOfQuestionRepository.CreateEntity(
                        new CourseTestBankOfQuestionDbo() { CourseTestId = result.InsertedId, BankOfQuestionId = bankOfQuestionId },
                        userId
                    );
                }
            }
            return result;
        }
    }
}
