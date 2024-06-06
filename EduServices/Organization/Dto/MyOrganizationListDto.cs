using Core.Base.Dto;
using EduServices.UserInOrganization.Dto;
using System;
using System.Collections.Generic;

namespace EduServices.Organization.Dto
{
    public class MyOrganizationListDto : BaseDto
    {
        public MyOrganizationListDto()
        {
            OrganizationRole = [];
        }

        public string Name { get; set; }
        public List<OrganizationRoleDto> OrganizationRole { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
