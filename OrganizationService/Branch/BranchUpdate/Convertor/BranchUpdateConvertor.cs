using Model.Edu.Branch;
using OrganizationService.Branch.BranchUpdate.Dto;

namespace OrganizationService.Branch.BranchUpdate.Convertor
{
    public class BranchUpdateConvertor : IBranchUpdateConvertor
    {
        public Task<BranchDbo> ConvertToBussinessEntity(BranchUpdateDto update, BranchDbo entity, string culture)
        {
            entity.City = update.City;
            entity.Region = update.Region;
            entity.CountryId = update.CountryId;
            entity.HouseNumber = update.HouseNumber;
            entity.Street = update.Street;
            entity.ZipCode = update.ZipCode;
            entity.Email = update.Email;
            entity.WWW = update.WWW;
            entity.PhoneNumber = update.PhoneNumber;
            entity.Name = update.Name;
            entity.BranchTranslations = entity.BranchTranslations.PrepareTranslation(update.Description, update.CultureId);
            entity.IsMainBranch = update.IsMainBranch;
            return Task.FromResult(entity);
        }
    }
}
