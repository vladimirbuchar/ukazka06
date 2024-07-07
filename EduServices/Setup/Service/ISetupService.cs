using Core.Base.Service;
using Core.DataTypes;
using Services.Setup.Dto;

namespace Services.Setup.Service
{
    public interface ISetupService : IBaseService
    {
        Result CreateAdministratorUser();
        Result ImportDefaultPermitions(bool delete);
        Result RegisterAllEndpoints();
        bool CheckUser(SetupLoginDto setupLogin);
    }
}
