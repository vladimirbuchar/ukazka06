﻿using System;
using Core.Base.Dto;

namespace EduServices.User.Dto
{
    public class LoginUserSocialNetworkDto : BaseDto
    {
        public string UserEmail { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
