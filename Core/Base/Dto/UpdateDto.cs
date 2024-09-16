using System;
using System.Text.Json.Serialization;

namespace Core.Base.Dto
{
    public class UpdateDto : BaseDto
    {
        public virtual Guid Id { get; set; }

        [JsonIgnore]
        public Guid CultureId { get; set; } = Guid.Empty;
    }
}
