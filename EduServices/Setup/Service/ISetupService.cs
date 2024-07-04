using Core.Base.Service;
using Core.DataTypes;
using EduServices.Setup.Dto;

namespace EduServices.Setup.Service
{
    public interface ISetupService : IBaseService
    {
        Result CreateAdministratorUser();
        Result ImportDefaultPermitions(bool delete);
        Result RegisterAllEndpoints();
        bool CheckUser(SetupLoginDto setupLogin);
    }
}
