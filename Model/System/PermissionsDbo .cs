using Model.Edu.OrganizationRole;
using System;

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
