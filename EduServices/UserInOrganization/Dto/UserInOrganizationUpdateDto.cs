﻿using Core.Base.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.UserInOrganization.Dto
{
    public class UserInOrganizationUpdateDto : UpdateDto
    {
        public List<Guid> OrganizationRoleId { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
