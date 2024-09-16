using Core.Base.Command;

namespace SetupService.GetAllEndpoints.Command
{
    public interface IGetAllEndpointsCommand : IBaseCommand
    {
        Task<List<string>> Execute();
    }
}