using UserService.UserProfile.MyTimeTable.Dto;

namespace UserService.UserProfile.MyTimeTable.Command
{
    public interface IMyTimeTableCommand
    {
        Task<List<MyTimeTableListDto>> Execute(Guid userId, List<string> culture);
    }
}