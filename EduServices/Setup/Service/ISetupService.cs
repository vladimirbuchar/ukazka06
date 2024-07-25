using Core.Base.Service;
using Core.DataTypes;
using Services.Setup.Dto;
using System.Threading.Tasks;

namespace Services.Setup.Service
{
    public interface ISetupService : IBaseService
    {
        Task<Result> CreateAdministratorUser();
        Task<Result> ImportDefaultPermitions(bool delete);
        Task<Result> RegisterAllEndpoints();
        Task<bool> CheckUser(SetupLoginDto setupLogin);
    }
}
