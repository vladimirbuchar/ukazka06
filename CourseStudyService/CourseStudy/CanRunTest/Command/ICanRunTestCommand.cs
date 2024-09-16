namespace CourseStudyService.CourseStudy.CanRunTest.Command
{
    public interface ICanRunTestCommand
    {
        Task<bool> Execute(Guid slideId, Guid userId);
    }
}