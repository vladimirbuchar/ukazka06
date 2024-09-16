using Core.Base.Command.Restore;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Restore.Command
{
    public class PermissionsRestoreService(IPermissionsRepository repository)
        : BaseRestoreCommand<PermissionsDbo, IPermissionsRepository>(repository),
            IPermissionsRestoreService
    { }
}
