using System;
using Model.Edu.OrganizationRole;

namespace Model.System
{
    public class PermissionsDbo : TableModel
    {
        public RouteDbo Route { get; set; }
        public Guid RouteId { get; set; }
        public OrganizationRoleDbo OrganizationRole { get; set; }
        public Guid OrganizationRoleId { get; set; }
    }
}
