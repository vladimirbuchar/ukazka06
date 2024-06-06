using Core.Base.Dto;
using System;

namespace EduServices.Permissions.Dto
{
    public class PermissionsCreateDto : CreateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }


    }
}
