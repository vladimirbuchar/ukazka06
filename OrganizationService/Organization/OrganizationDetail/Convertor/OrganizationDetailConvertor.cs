using Core.Constants;
using Core.DataTypes;
using Microsoft.Extensions.Configuration;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationDetail.Dto;

namespace OrganizationService.Organization.OrganizationDetail.Convertor
{
    public class OrganizationDetailConvertor : IOrganizationDetailConvertor
    {
        private readonly string _fileServerUrl;

        public OrganizationDetailConvertor(IConfiguration configuration)
        {
            _fileServerUrl = configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value;
        }

        public Task<OrganizationDetailDto> ConvertToWebModel(OrganizationDbo detail, List<string> culture)
        {
            List<Address>? addresss = detail
                .Addresses?.Select(item => new Address()
                {
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    Id = item.Id
                })
                .ToList();
            return Task.FromResult(
                new OrganizationDetailDto()
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    WWW = detail.WWW,
                    LicenseId = detail.LicenseId,
                    Addresses = addresss,
                    Logo = string.Format(
                        "{0}{1}/{2}",
                        _fileServerUrl,
                        detail.Id,
                        detail.OrganizationFileRepositories.FindTranslation(culture)?.FileName
                    )
                }
            );
        }
    }
}
