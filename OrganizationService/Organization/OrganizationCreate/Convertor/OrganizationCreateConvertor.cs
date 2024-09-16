using Model.Edu.Organization;
using Model.Edu.OrganizationAddress;
using Model.Edu.OrganizationSetting;
using OrganizationService.Organization.OrganizationCreate.Dto;

namespace OrganizationService.Organization.OrganizationCreate.Convertor
{
    public class OrganizationCreateConvertor : IOrganizationCreateConvertor
    {
        public OrganizationCreateConvertor() { }

        public Task<OrganizationDbo> ConvertToBussinessEntity(OrganizationCreateDto create, string culture)
        {
            List<OrganizationAddressDbo>? addresses = create
                .Addresses?.Select(item => new OrganizationAddressDbo()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    OrganizationId = Guid.Empty
                })
                .ToList();
            return Task.FromResult(
                new OrganizationDbo()
                {
                    Name = create.Name,
                    Email = create.Email,
                    PhoneNumber = create.PhoneNumber,
                    WWW = create.WWW,
                    LicenseId = create.LicenceId,
                    Addresses = addresses,
                    OrganizationSetting = new OrganizationSettingDbo()
                    {
                        ElearningUrl = create.ElearningUrl,
                        UserDefaultPassword = create.Name,
                        UseCustomSmtpServer = false
                    }
                }
            );
        }
    }
}
