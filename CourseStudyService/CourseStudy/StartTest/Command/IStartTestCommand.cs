using CourseStudyService.CourseStudy.StartTest.Dto;

namespace CourseStudyService.CourseStudy.StartTest.Command
{
    public interface IStartTestCommand
    {
        Task<Guid> Execute(StartTestDto startTest);
    }
}