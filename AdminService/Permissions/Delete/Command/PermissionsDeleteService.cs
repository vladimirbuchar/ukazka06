using Core.Base.Command.Delete;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Delete.Command
{
    public class PermissionsDeleteService(IPermissionsRepository repository)
        : BaseDeleteCommand<PermissionsDbo, IPermissionsRepository>(repository),
            IPermissionsDeleteService
    { }
}
