﻿using System.Collections.Generic;

namespace Model.System
{
    public class RouteDbo : TableModel
    {
        public string Route { get; set; }
        public ICollection<PermissionsDbo> Permissions { get; set; }
    }
}
