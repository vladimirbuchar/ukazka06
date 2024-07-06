using Core.Base.Repository.CodeBookRepository;
using EduServices.Branch.Dto;
using Model.CodeBook;
using Model.Edu.Branch;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Branch.Convertor
{
    public class BranchConvertor(ICodeBookRepository<CultureDbo> codeBookService) : IBranchConvertor
    {
        private readonly HashSet<CultureDbo> _cultureList = codeBookService.GetEntities(false);

        public BranchDbo ConvertToBussinessEntity(BranchCreateDto addBranchDto, string culture)
        {
            BranchDbo branch = new()
            {
                City = addBranchDto?.City,
                Region = addBranchDto?.Region,
                CountryId = addBranchDto?.CountryId,
                HouseNumber = addBranchDto?.HouseNumber,
                Street = addBranchDto?.Street,
                ZipCode = addBranchDto?.ZipCode,
                Email = addBranchDto.Email,
                WWW = addBranchDto.WWW,
                PhoneNumber = addBranchDto.PhoneNumber,
                OrganizationId = addBranchDto.OrganizationId,
                IsMainBranch = addBranchDto.IsMainBranch,
                IsOnline = addBranchDto.IsOnline,
            };
            branch.BranchTranslations = branch.BranchTranslations.PrepareTranslation(addBranchDto.Name, addBranchDto.Description, culture, _cultureList);
            return branch;
        }

        public BranchDbo ConvertToBussinessEntity(BranchUpdateDto updateBranchDto, BranchDbo entity, string culture)
        {
            entity.City = updateBranchDto?.City;
            entity.Region = updateBranchDto?.Region;
            entity.CountryId = updateBranchDto?.CountryId;
            entity.HouseNumber = updateBranchDto?.HouseNumber;
            entity.Street = updateBranchDto?.Street;
            entity.ZipCode = updateBranchDto?.ZipCode;
            entity.Email = updateBranchDto.Email;
            entity.WWW = updateBranchDto.WWW;
            entity.PhoneNumber = updateBranchDto.PhoneNumber;
            entity.BranchTranslations = entity.BranchTranslations.PrepareTranslation(updateBranchDto.Name, updateBranchDto.Description, culture, _cultureList);
            entity.IsMainBranch = updateBranchDto.IsMainBranch;
            return entity;
        }

        public HashSet<BranchListDto> ConvertToWebModel(HashSet<BranchDbo> getAllBranchInOrganizations, string culture)
        {
            return getAllBranchInOrganizations
                .Select(item => new BranchListDto()
                {
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                    Description = item.BranchTranslations?.FindTranslation(culture)?.Description,
                    Name = item.BranchTranslations?.FindTranslation(culture)?.Name,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    WWW = item.WWW,
                    Id = item.Id,
                    IsMainBranch = item.IsMainBranch,
                    IsOnline = item.IsOnline
                })
                .ToHashSet();
        }

        public BranchDetailDto ConvertToWebModel(BranchDbo getBranchDetail, string culture)
        {
            return new BranchDetailDto()
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
            };
        }
    }
}
