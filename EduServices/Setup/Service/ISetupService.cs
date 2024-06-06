using Core.Base.Service;
using EduServices.Setup.Dto;

namespace EduServices.Setup.Service
{
    public interface ISetupService : IBaseService
    {
        void CreateAdministratorUser();
        void ImportDefaultPermitions(bool delete);
        void RegisterAllEndpoints();
        bool CheckUser(SetupLoginDto setupLogin);
    }
}
