using Core.Base.Dto;
using Core.DataTypes;
using System;

namespace Core.Base
{
    public class TestRequestSettings : ListDto
    {
        public Guid OrganizationId { get; set; }
        public OperationType OperationType { get; set; }

    }
}
