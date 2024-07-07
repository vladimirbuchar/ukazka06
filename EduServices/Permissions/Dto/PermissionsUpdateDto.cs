using System;
using Core.Base.Dto;

namespace Services.Permissions.Dto
{
    public class PermissionsUpdateDto : UpdateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
