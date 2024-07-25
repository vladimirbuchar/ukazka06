using Core.Base.Repository.CodeBookRepository;
using Model.CodeBook;
using Model.Edu.Branch;
using Services.Branch.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Branch.Convertor
{
    public class BranchConvertor(ICodeBookRepository<CultureDbo> codeBookRepository) : IBranchConvertor
    {
        private readonly List<CultureDbo> _cultureList = codeBookRepository.GetEntities(false).Result;

        public Task<BranchDbo> ConvertToBussinessEntity(BranchCreateDto addBranchDto, string culture)
        {
            BranchDbo branch =
                new()
                {
                    City = addBranchDto.City,
                    Region = addBranchDto.Region,
                    CountryId = addBranchDto.CountryId,
                    HouseNumber = addBranchDto.HouseNumber,
                    Street = addBranchDto.Street,
                    ZipCode = addBranchDto.ZipCode,
                    Email = addBranchDto.Email,
                    WWW = addBranchDto.WWW,
                    PhoneNumber = addBranchDto.PhoneNumber,
                    OrganizationId = addBranchDto.OrganizationId,
                    IsMainBranch = addBranchDto.IsMainBranch,
                    IsOnline = addBranchDto.IsOnline,
                };
            branch.BranchTranslations = branch.BranchTranslations.PrepareTranslation(
                addBranchDto.Name,
                addBranchDto.Description,
                culture,
                _cultureList
            );
            return Task.FromResult(branch);
        }

        public Task<BranchDbo> ConvertToBussinessEntity(BranchUpdateDto updateBranchDto, BranchDbo entity, string culture)
        {
            entity.City = updateBranchDto.City;
            entity.Region = updateBranchDto.Region;
            entity.CountryId = updateBranchDto.CountryId;
            entity.HouseNumber = updateBranchDto.HouseNumber;
            entity.Street = updateBranchDto.Street;
            entity.ZipCode = updateBranchDto.ZipCode;
            entity.Email = updateBranchDto.Email;
            entity.WWW = updateBranchDto.WWW;
            entity.PhoneNumber = updateBranchDto.PhoneNumber;
            entity.BranchTranslations = entity.BranchTranslations.PrepareTranslation(
                updateBranchDto.Name,
                updateBranchDto.Description,
                culture,
                _cultureList
            );
            entity.IsMainBranch = updateBranchDto.IsMainBranch;
            return Task.FromResult(entity);
        }

        public Task<List<BranchListDto>> ConvertToWebModel(List<BranchDbo> getAllBranchInOrganizations, string culture)
        {
            return Task.FromResult(getAllBranchInOrganizations
                .Select(item => new BranchListDto()
                {
                    City = item.City,
                    CountryId = item.CountryId,
                    CountryName = item.Country.Name,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    Name = item.BranchTranslations?.FindTranslation(culture)?.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    WWW = item.WWW,
                    Id = item.Id,
                    IsMainBranch = item.IsMainBranch
                })
                .ToList());
        }

        public Task<BranchDetailDto> ConvertToWebModel(BranchDbo getBranchDetail, string culture)
        {
            return Task.FromResult(new BranchDetailDto()
            {
                City = getBranchDetail.City,
                CountryId = getBranchDetail.CountryId,
                HouseNumber = getBranchDetail.HouseNumber,
                Region = getBranchDetail.Region,
                Street = getBranchDetail.Street,
                ZipCode = getBranchDetail.ZipCode,
                Description = getBranchDetail.BranchTranslations?.FindTranslation(culture)?.Description,
                Name = getBranchDetail.BranchTranslations?.FindTranslation(culture)?.Name,
                Email = getBranchDetail.Email,
                PhoneNumber = getBranchDetail.PhoneNumber,
                WWW = getBranchDetail.WWW,
                Id = getBranchDetail.Id,
                IsMainBranch = getBranchDetail.IsMainBranch
            });
        }
    }
}
