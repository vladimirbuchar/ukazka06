using System.ComponentModel.DataAnnotations;
using Core.Base.Dto;

namespace Services.Setup.Dto
{
    public class SetupLoginDto : BaseDto
    {
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
