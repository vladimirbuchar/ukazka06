using Model.Edu.Branch;
using OrganizationService.Branch.BranchCreate.Dto;

namespace OrganizationService.Branch.BranchCreate.Convertor
{
    public class BranchCreateConvertor : IBranchCreateConvertor
    {
        public Task<BranchDbo> ConvertToBussinessEntity(BranchCreateDto create, string culture)
        {
            BranchDbo branch =
                new()
                {
                    City = create.City,
                    Region = create.Region,
                    CountryId = create.CountryId,
                    HouseNumber = create.HouseNumber,
                    Street = create.Street,
                    ZipCode = create.ZipCode,
                    Email = create.Email,
                    WWW = create.WWW,
                    PhoneNumber = create.PhoneNumber,
                    OrganizationId = create.OrganizationId,
                    IsMainBranch = create.IsMainBranch,
                    IsOnline = create.IsOnline,
                };
            branch.BranchTranslations = branch.BranchTranslations.PrepareTranslation(create.Description, create.CultureId);
            return Task.FromResult(branch);
        }
    }
}
