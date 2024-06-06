using System;

namespace Core.DataTypes
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid? CountryId { get; set; } = Guid.Empty;
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public Guid AddressTypeId { get; set; } = Guid.Empty;
    }
}
