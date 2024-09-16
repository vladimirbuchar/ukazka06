using Model.Edu.Branch;
using OrganizationService.Branch.BranchList.Dto;

namespace OrganizationService.Branch.BranchList.Convertor
{
    public class BranchListConvertor : IBranchListConvertor
    {
        public Task<List<BranchListDto>> ConvertToWebModel(List<BranchDbo> list, List<string> culture)
        {
            return Task.FromResult(
                list.Select(item => new BranchListDto()
                {
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    Name = item.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    WWW = item.WWW,
                    Id = item.Id,
                    IsMainBranch = item.IsMainBranch
                })
                    .ToList()
            );
        }
    }
}
