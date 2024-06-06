using EduServices.Permissions.Dto;
using Model.Tables.System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Permissions.Convertor
{
    public class PermissionsConvertor() : IPermissionsConvertor
    {
        public PermissionsDbo ConvertToBussinessEntity(PermissionsUpdateDto update, PermissionsDbo entity, string culture)
        {
            entity.RouteId = update.RouteId;
            entity.OrganizationRoleId = update.OrganizationRoleId;
            return entity;
        }

        public PermissionsDbo ConvertToBussinessEntity(PermissionsCreateDto create, string culture)
        {
            return new PermissionsDbo()
            {
                RouteId = create.RouteId,
                OrganizationRoleId = create.OrganizationRoleId
            };
        }

        public HashSet<PermissionsListDto> ConvertToWebModel(HashSet<PermissionsDbo> list, string culture)
        {
            return list.Select(x => new PermissionsListDto()
            {
                Id = x.Id,
                OrganizationRole = x.OrganizationRole.SystemIdentificator,
                Route = x.Route.Route
            }).ToHashSet();
        }

        public PermissionsDetailDto ConvertToWebModel(PermissionsDbo detail, string culture)
        {
            return new PermissionsDetailDto()
            {
                Id = detail.Id,
                OrganizationRole = detail.OrganizationRole.SystemIdentificator,
                Route = detail.Route.Route
            };
        }
    }
}
