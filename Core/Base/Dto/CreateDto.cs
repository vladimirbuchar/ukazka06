using System;
using System.Text.Json.Serialization;

namespace Core.Base.Dto
{
    public class CreateDto : BaseDto
    {
        [JsonIgnore]
        public Guid CultureId { get; set; } = Guid.Empty;
    }
}
