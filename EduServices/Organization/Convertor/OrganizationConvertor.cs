﻿using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using Microsoft.Extensions.Configuration;
using Model.CodeBook;
using Model.Edu.BankOfQuestions;
using Model.Edu.Branch;
using Model.Edu.ClassRoom;
using Model.Edu.Organization;
using Model.Edu.OrganizationAddress;
using Model.Edu.OrganizationSetting;
using Model.Link;
using Repository.OrganizationRoleRepository;
using Services.Organization.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Organization.Convertor
{
    public class OrganizationConvertor(
        IConfiguration configuration,
        ICodeBookRepository<LicenseDbo> licences,
        ICodeBookRepository<CountryDbo> countries,
        IOrganizationRoleRepository organizationRoleRepository
    ) : IOrganizationConvertor
    {
        private readonly List<LicenseDbo> _licences = licences.GetEntities(false).Result;
        private readonly List<CountryDbo> _countries = countries.GetEntities(false).Result;
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly string _elearningUrl = configuration.GetSection(ConfigValue.ELEARNING_URL).Value;
        private readonly string _fileServerUrl = configuration.GetSection(ConfigValue.FILE_SERVER_URL).Value;

        public async Task<OrganizationDbo> ConvertToBussinessEntity(OrganizationCreateDto addOrganizationDto, string culture)
        {
            Guid ownerRoleId = (await _organizationRoleRepository
                            .GetEntity(false, x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER)).Id;
            List<OrganizationAddressDbo> addresses = addOrganizationDto
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
            return await Task.FromResult(new OrganizationDbo()

            {
                Name = addOrganizationDto.Name,
                Email = addOrganizationDto.Email,
                PhoneNumber = addOrganizationDto.PhoneNumber,
                WWW = addOrganizationDto.WWW,
                LicenseId = _licences.FirstOrDefault(x => x.SystemIdentificator == License.FREE).Id,
                Addresses = addresses,
                BankOfQuestions =
                [
                    new BankOfQuestionDbo()
                    {
                        BankOfQuestionsTranslations =
                        [
                            new BankOfQuestionsTranslationDbo()
                            {
                                Name = Constants.DEFAULT_BANK_OF_QUESTION,
                                CultureId = addOrganizationDto.DefaultCultureId,
                            }
                        ],
                        IsDefault = true
                    }
                ],
                OrganizationCultures = [new OrganizationCultureDbo() { CultureId = addOrganizationDto.DefaultCultureId, IsDefault = true, }],
                UserInOrganizations =
                [
                    new UserInOrganizationDbo()
                    {
                        UserId = addOrganizationDto.UserId,
                        OrganizationRoleId =  ownerRoleId
                    }
                ],
                Branch =
                [
                    new BranchDbo()
                    {
                        BranchTranslations =
                        [
                            new BranchTranslationDbo()
                            {
                                Name = Constants.ONLINE_BRANCH,
                                Description = "",
                                CultureId = addOrganizationDto.DefaultCultureId
                            }
                        ],
                        City = "",
                        CountryId = _countries.FirstOrDefault(x => x.IsDefault).Id,
                        HouseNumber = "",
                        Region = "",
                        Street = "",
                        ZipCode = "",
                        Email = "",
                        PhoneNumber = "",
                        WWW = "",
                        IsMainBranch = false,
                        IsOnline = true,
                        ClassRoom =
                        [
                            new ClassRoomDbo()
                            {
                                ClassRoomTranslations =
                                [
                                    new ClassRoomTranslationDbo()
                                    {
                                        Name = Constants.ONLINE_CLASSROOM,
                                        CultureId = addOrganizationDto.DefaultCultureId
                                    }
                                ],
                                Floor = 0,
                                IsOnline = true,
                                MaxCapacity = 0
                            }
                        ]
                    }
                ],
                OrganizationSetting = new OrganizationSettingDbo()
                {
                    ElearningUrl = string.Format("{0}{1}", _elearningUrl, Guid.NewGuid().ToString()),
                    UserDefaultPassword = addOrganizationDto.Name,
                    UseCustomSmtpServer = false
                }
            });
        }

        public Task<OrganizationDbo> ConvertToBussinessEntity(OrganizationUpdateDto updateOrganizationDto, OrganizationDbo entity, string culture)
        {
            foreach (OrganizationAddressDbo addr in entity.Addresses)
            {
                if (updateOrganizationDto.Addresses.FirstOrDefault(x => x.Id == addr.Id) == null)
                {
                    addr.IsDeleted = true;
                }
            }
            foreach (Address address in updateOrganizationDto.Addresses)
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
            entity.Name = updateOrganizationDto.Name;
            entity.Email = updateOrganizationDto.Email;
            entity.PhoneNumber = updateOrganizationDto.PhoneNumber;
            entity.WWW = updateOrganizationDto.WWW;
            return Task.FromResult(entity);
        }

        public Task<OrganizationDetailDto> ConvertToWebModel(OrganizationDbo getOrganizationDetail, string culture = "")
        {
            List<Address> addresss = getOrganizationDetail
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
            return Task.FromResult(new OrganizationDetailDto()
            {
                Id = getOrganizationDetail.Id,
                Name = getOrganizationDetail.Name,
                Email = getOrganizationDetail.Email,
                PhoneNumber = getOrganizationDetail.PhoneNumber,
                WWW = getOrganizationDetail.WWW,
                LicenseId = getOrganizationDetail.LicenseId,
                Addresses = addresss,
                Logo = string.Format(
                    "{0}{1}/{2}",
                    _fileServerUrl,
                    getOrganizationDetail.Id,
                    getOrganizationDetail.OrganizationFileRepositories.FindTranslation(culture)?.FileName
                )
            });
        }

        public Task<List<OrganizationListDto>> ConvertToWebModel(List<OrganizationDbo> getAllOrganizations, string culture = "")
        {
            return Task.FromResult(getAllOrganizations
                .Select(item => new OrganizationListDto()
                {
                    //Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                })
                .ToList());
        }

        public OrganizationDetailWebDto ConvertToWebModelWeb(OrganizationDbo getOrganizationDetail)
        {
            return new OrganizationDetailWebDto()
            {
                Id = getOrganizationDetail.Id,
                //Description = getOrganizationDetail.Description,
                Name = getOrganizationDetail.Name,
                Email = getOrganizationDetail.Email,
                PhoneNumber = getOrganizationDetail.PhoneNumber,
                WWW = getOrganizationDetail.WWW
            };
        }

        public OrganizationCreateDto ConvertToWebModelWebForUser(OrganizationCreateByUserDto organizationCreateByUser)
        {
            return new OrganizationCreateDto()
            {
                Addresses = organizationCreateByUser.Addresses,
                DefaultCultureId = organizationCreateByUser.DefaultCultureId,
                Email = organizationCreateByUser.Email,
                Name = organizationCreateByUser.Name,
                PhoneNumber = organizationCreateByUser.PhoneNumber,
                WWW = organizationCreateByUser.WWW,
                UserId = Guid.Empty,
            };
        }


    }
}
