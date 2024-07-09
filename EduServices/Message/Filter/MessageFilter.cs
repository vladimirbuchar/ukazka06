using System;
using System.Collections.Generic;
using Core.Base.Request;

namespace Services.Message.Filter
{
    public class MessageFilter : FilterRequest
    {
        public string Name { get; set; }
        public List<Guid> SendMessageTypeId { get; set; } = [];
        public string Reply { get; set; }
    }
}
