using System;
using System.Collections.Generic;
using Core.Base.Filter;

namespace Services.Message.Filter
{
    public class MessageFilter : FilterRequest
    {
        public string Name { get; set; }
        public List<Guid> SendMessageTypeId { get; set; } = [];
        public string Reply { get; set; }
    }
}
