using Core.DataTypes;
using Model.Edu.Organization;
using Model.Edu.OrganizationAddress;
using OrganizationService.Organization.OrganizationUpdate.Dto;

namespace OrganizationService.Organization.OrganizationUpdate.Convertor
{
    public class OrganizationUpdateConvertor : IOrganizationUpdateConvertor
    {
        public Task<OrganizationDbo> ConvertToBussinessEntity(OrganizationUpdateDto update, OrganizationDbo entity, string culture)
        {
            foreach (OrganizationAddressDbo addr in entity.Addresses)
            {
                if (update.Addresses.FirstOrDefault(x => x.Id == addr.Id) == null)
                {
                    addr.IsDeleted = true;
                }
            }
            foreach (Address address in update.Addresses)
            {
                OrganizationAddressDbo organizationAddress = entity.Addresses.FirstOrDefault(x => x.Id == address.Id);
                if (organizationAddress == null)
                {
                    entity.Addresses.Add(
                        new OrganizationAddressDbo()
                        {
                            AddressTypeId = address.AddressTypeId,
                            City = address.City,
                            CountryId = address.CountryId,
                            HouseNumber = address.HouseNumber,
                            Region = address.Region,
                            Street = address.Street,
                            ZipCode = address.ZipCode,
                        }
                    );
                }
                else
                {
                    organizationAddress.AddressTypeId = address.AddressTypeId;
                    organizationAddress.City = address.City;
                    organizationAddress.CountryId = address.CountryId;
                    organizationAddress.HouseNumber = address.HouseNumber;
                    organizationAddress.Region = address.Region;
                    organizationAddress.Street = address.Street;
                    organizationAddress.ZipCode = address.ZipCode;
                }
            }
            entity.Name = update.Name;
            entity.Email = update.Email;
            entity.PhoneNumber = update.PhoneNumber;
            entity.WWW = update.WWW;
            return Task.FromResult(entity);
        }
    }
}
