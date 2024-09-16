using Core.Base.Command;
using CourseStudyService.CourseStudy.StartTest.Dto;
using Model.Edu.StudentTestSummary;
using Repository.StudentTestSummary;

namespace CourseStudyService.CourseStudy.StartTest.Command
{
    public class StartTestCommand : BaseCommand<IStudentTestSummaryRepository>, IStartTestCommand
    {
        public StartTestCommand(IStudentTestSummaryRepository repository) : base(repository)
        {
        }

        public async Task<Guid> Execute(StartTestDto startTest)
        {
            // CourseTestDbo courseTestDbo = await _testRepository.GetEntity(false, x => x.CourseLessonId == courseLessonId);

            return (
                await _repository.CreateEntity(
                    new StudentTestSummaryDbo()
                    {
                        StartTime = DateTime.Now,
                        CourseTestId = startTest.TestId,
                        UserId = startTest.UserId,
                        CourseId = startTest.CourseId
                    },
                    startTest.UserId
                )
            ).Id;
        }
    }
}
