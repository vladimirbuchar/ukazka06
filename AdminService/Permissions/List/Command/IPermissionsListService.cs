using AdminService.Permissions.List.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Model.System;

namespace AdminService.Permissions.List.Command
{
    public interface IPermissionsListService : IBaseListCommand<PermissionsDbo, PermissionsListDto, RequestFilter> { }
}
