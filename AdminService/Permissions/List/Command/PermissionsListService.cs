using AdminService.Permissions.List.Convertor;
using AdminService.Permissions.List.Dto;
using Core.Base.Command.List;
using Core.Base.Filter;
using Model.System;
using Repository.Permissions;

namespace AdminService.Permissions.List.Command
{
    public class PermissionsListService(IPermissionsRepository repository, IPermissionsListConvertor convertor)
        : BaseListCommand<PermissionsDbo, IPermissionsRepository, PermissionsListDto, IPermissionsListConvertor, RequestFilter>(
            repository,
            convertor
        ),
            IPermissionsListService
    { }
}
