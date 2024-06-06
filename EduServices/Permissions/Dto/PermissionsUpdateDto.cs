using Core.Base.Dto;
using System;

namespace EduServices.Permissions.Dto
{
    public class PermissionsUpdateDto : UpdateDto
    {
        public Guid RouteId { get; set; }
        public Guid OrganizationRoleId { get; set; }


    }
}
