using System;
using Core.Base.Dto;

namespace Services.Permissions.Dto
{
    public class PermissionsCreateDto : CreateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
