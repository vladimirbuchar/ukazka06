using Core.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace UserService.User.GetUserToken.Dto
{
    public class GetUserTokenDto : BaseDto
    {
        public string? UserEmail { get; set; }

        [DataType(DataType.Password)]
        public string? UserPassword { get; set; }
        public Guid? OrganizationId { get; set; }
    }
}
