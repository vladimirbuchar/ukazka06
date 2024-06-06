﻿using Core.Base.Repository.CodeBookRepository;
using Core.Constants;
using Core.DataTypes;
using EduRepository.OrganizationRoleRepository;
using EduServices.Organization.Dto;
using Microsoft.Extensions.Configuration;
using Model.Tables.CodeBook;
using Model.Tables.Edu.BankOfQuestions;
using Model.Tables.Edu.Branch;
using Model.Tables.Edu.ClassRoom;
using Model.Tables.Edu.Organization;
using Model.Tables.Edu.OrganizationAddress;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Link;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduServices.Organization.Convertor
{
    public class OrganizationConvertor(
        IConfiguration configuration,
        ICodeBookRepository<LicenseDbo> licences,
        ICodeBookRepository<CountryDbo> countries,
        IOrganizationRoleRepository organizationRoleRepository
        ) : IOrganizationConvertor
    {
        private readonly HashSet<LicenseDbo> _licences = licences.GetCodeBookItems();
        private readonly HashSet<CountryDbo> _countries = countries.GetCodeBookItems();
        private readonly IOrganizationRoleRepository _organizationRoleRepository = organizationRoleRepository;
        private readonly string _elearningUrl = configuration.GetSection(ConfigValue.ElearningUrl).Value;

        public OrganizationDbo ConvertToBussinessEntity(OrganizationCreateDto addOrganizationDto, string culture)
        {
            HashSet<OrganizationAddressDbo> addresses = addOrganizationDto
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
                .ToHashSet();
            return new OrganizationDbo()
            {
                CanSendCourseInquiry = addOrganizationDto.CanSendCourseInquiry,
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
                            new BankOfQuestionsTranslationDbo() { Name = Constants.DEFAULT_BANK_OF_QUESTION, CultureId = addOrganizationDto.DefaultCultureId, }
                        ],
                        IsDefault = true
                    }
                ],
                OrganizationCultures =
                [
                    new OrganizationCultureDbo() { CultureId = addOrganizationDto.DefaultCultureId, IsDefault = true, }
                ],
                UserInOrganizations =
                [
                    new UserInOrganizationDbo()
                    {
                        UserId = addOrganizationDto.UserId,
                        OrganizationRoleId = _organizationRoleRepository.GetEntity(false,x => x.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER).Id
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
                                    new ClassRoomTranslationDbo() { Name = Constants.ONLINE_CLASSROOM, CultureId = addOrganizationDto.DefaultCultureId }
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
            };
        }

        public OrganizationDbo ConvertToBussinessEntity(OrganizationUpdateDto updateOrganizationDto, OrganizationDbo entity, string culture)
        {
            HashSet<OrganizationAddressDbo> addresses = updateOrganizationDto
                .Addresses.Select(item => new OrganizationAddressDbo()
                {
                    Id = item.Id,
                    AddressTypeId = item.AddressTypeId,
                    City = item.City,
                    CountryId = item.CountryId,
                    HouseNumber = item.HouseNumber,
                    Region = item.Region,
                    Street = item.Street,
                    ZipCode = item.ZipCode,
                })
                .ToHashSet();

            entity.Name = updateOrganizationDto.Name;
            entity.CanSendCourseInquiry = updateOrganizationDto.CanSendCourseInquiry;
            entity.Email = updateOrganizationDto.Email;
            entity.PhoneNumber = updateOrganizationDto.PhoneNumber;
            entity.WWW = updateOrganizationDto.WWW;
            entity.Addresses = addresses;
            return entity;
        }

        public OrganizationDetailDto ConvertToWebModel(OrganizationDbo getOrganizationDetail, string culture = "")
        {
            HashSet<Address> addresss = getOrganizationDetail
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
                .ToHashSet();
            return new OrganizationDetailDto()
            {
                Id = getOrganizationDetail.Id,
                Name = getOrganizationDetail.Name,
                Email = getOrganizationDetail.Email,
                PhoneNumber = getOrganizationDetail.PhoneNumber,
                WWW = getOrganizationDetail.WWW,
                CanSendCourseInquiry = getOrganizationDetail.CanSendCourseInquiry,
                LicenseId = getOrganizationDetail.LicenseId,
                Addresses = addresss
            };
        }

        public HashSet<OrganizationListDto> ConvertToWebModel(HashSet<OrganizationDbo> getAllOrganizations, string culture = "")
        {
            return getAllOrganizations
                .Select(item => new OrganizationListDto()
                {
                    //Description = item.Description,
                    Id = item.Id,
                    Name = item.Name,
                })
                .ToHashSet();
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
                CanSendCourseInquiry = organizationCreateByUser.CanSendCourseInquiry,
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
