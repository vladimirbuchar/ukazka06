using System.Collections.Generic;
using System.Linq;
using Model.System;
using Services.Permissions.Dto;

namespace Services.Permissions.Convertor
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
            return new PermissionsDbo() { RouteId = create.RouteId, OrganizationRoleId = create.OrganizationRoleId };
        }

        public List<PermissionsListDto> ConvertToWebModel(List<PermissionsDbo> list, string culture)
        {
            return list.Select(x => new PermissionsListDto()
                {
                    Id = x.Id,
                    OrganizationRole = x.OrganizationRole.SystemIdentificator,
                    Route = x.Route.Route
                })
                .ToList();
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
