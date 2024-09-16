using AdminService.Permissions.Detail.Convertor;
using AdminService.Permissions.Detail.Dto;
using Core.Base.Command.Detail;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.Detail.Command
{
    public class PermissionsDetailService(IPermissionsRepository repository, IPermissionsDetailConvertor convertor)
        : BaseDetailCommand<PermissionsDbo, IPermissionsRepository, PermissionsDetailDto, IPermissionsDetailConvertor>(repository, convertor),
            IPermissionsDetailService
    { }
}
