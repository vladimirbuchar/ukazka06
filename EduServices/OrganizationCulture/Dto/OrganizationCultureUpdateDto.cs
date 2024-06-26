﻿using Core.Base.Dto;
using System;
using System.Text.Json.Serialization;

namespace EduServices.OrganizationCulture.Dto
{

    public class OrganizationCultureUpdateDto : UpdateDto
    {
        public bool IsDefault { get; set; }
        [JsonIgnore]
        public Guid OrganizationId { get; set; }

    }
}
