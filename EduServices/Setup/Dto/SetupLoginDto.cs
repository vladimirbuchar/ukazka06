﻿using Core.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace Services.Setup.Dto
{
    public class SetupLoginDto : BaseDto
    {
        public string UserEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
