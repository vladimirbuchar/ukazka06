using Core.Base.Command;
using Model.Edu.CourseTest;
using Model.Edu.StudentTestSummary;
using Repository.Test;

namespace CourseStudyService.CourseStudy.CanRunTest.Command
{
    public class CanRunTestCommand : BaseCommand<TestRepository>, ICanRunTestCommand
    {
        public CanRunTestCommand(TestRepository repository) : base(repository)
        {
        }
        public async Task<bool> Execute(Guid slideId, Guid userId)
        {
            CourseTestDbo getCourseTestDetail = await _repository.GetEntity(false, x => x.CourseLessonId == slideId);
            List<StudentTestSummaryDbo> tests = getCourseTestDetail.StudentTestSummaries.Where(x => x.UserId == userId).ToList();
            if (getCourseTestDetail.MaxRepetition == 0)
            {
                return true;
            }
            else if (getCourseTestDetail.MaxRepetition == -1 && tests.FirstOrDefault(x => x.IsSucess) == null)
            {
                return true;
            }
            else if (getCourseTestDetail.MaxRepetition >= tests.Count)
            {
                return true;
            }
            return false;
        }
    }
}
