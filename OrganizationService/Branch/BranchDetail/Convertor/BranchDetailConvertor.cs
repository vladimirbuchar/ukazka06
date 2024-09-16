using Model.Edu.Branch;
using OrganizationService.Branch.BranchDetail.Dto;

namespace OrganizationService.Branch.BranchDetail.Convertor
{
    public class BranchDetailConvertor : IBranchDetailConvertor
    {
        public Task<BranchDetailDto> ConvertToWebModel(BranchDbo detail, List<string> culture)
        {
            return Task.FromResult(
                new BranchDetailDto()
                {
                    City = detail.City,
                    CountryId = detail.CountryId,
                    HouseNumber = detail.HouseNumber,
                    Region = detail.Region,
                    Street = detail.Street,
                    ZipCode = detail.ZipCode,
                    Description = detail.BranchTranslations?.FindTranslation(culture)?.Description,
                    Name = detail.Name,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    WWW = detail.WWW,
                    Id = detail.Id,
                    IsMainBranch = detail.IsMainBranch
                }
            );
        }
    }
}
