﻿using System.Collections.Generic;
using System.Linq;
using EduServices.OrganizationCulture.Dto;
using EduServices.OrganizationSetting.Dto;
using Model.Tables.Edu.OrganizationSetting;
using Model.Tables.Link;

namespace EduServices.OrganizationSetting.Convertor
{
    public class OrganizationSettingConvertor : IOrganizationSettingConvertor
    {
        public OrganizationSettingConvertor() { }

        public OrganizationSettingDbo ConvertToBussinessEntity(OrganizationSettingUpdateDto saveOrganizationSettingDto, OrganizationSettingDbo setting)
        {
            setting.UserDefaultPassword = saveOrganizationSettingDto.UserDefaultPassword;
            //setting.LicenseOldId = saveOrganizationSettingDto.LicenseId;
            setting.ElearningUrl = saveOrganizationSettingDto.UrlElearning;
            setting.Registration = saveOrganizationSettingDto.Registration;
            setting.PasswordReset = saveOrganizationSettingDto.PasswordReset;
            setting.GoogleLogin = saveOrganizationSettingDto.GoogleLogin;
            setting.FacebookLogin = saveOrganizationSettingDto.FacebookLogin;
            setting.LessonLength = saveOrganizationSettingDto.LessonLength;
            setting.BackgroundColor = saveOrganizationSettingDto.BackgroundColor;
            setting.TextColor = saveOrganizationSettingDto.TextColor;
            setting.SmtpServerPassword = saveOrganizationSettingDto.SmtpServerPassword;
            setting.SmtpServerPort = saveOrganizationSettingDto.SmtpServerPort;
            setting.SmtpServerUrl = saveOrganizationSettingDto.SmtpServerUrl;
            setting.SmtpServerUserName = saveOrganizationSettingDto.SmtpServerUserName;
            setting.UseCustomSmtpServer = saveOrganizationSettingDto.UseCustomSmtpServer;
            setting.GoogleApiToken = saveOrganizationSettingDto.GoogleApiToken;
            return setting;
        }

        public OrganizationSettingDetailDto ConvertToWebModel(OrganizationSettingDbo getOrganizationSetting)
        {
            return new OrganizationSettingDetailDto()
            {
                OrganizationId = getOrganizationSetting.OrganizationId,
                UserDefaultPassword = getOrganizationSetting.UserDefaultPassword,
                ElearningUrl = getOrganizationSetting.ElearningUrl,
                FacebookLogin = getOrganizationSetting.FacebookLogin,
                GoogleLogin = getOrganizationSetting.GoogleLogin,
                PasswordReset = getOrganizationSetting.PasswordReset,
                Registration = getOrganizationSetting.Registration,
                LessonLength = getOrganizationSetting.LessonLength,
                TextColor = getOrganizationSetting.TextColor,
                BackgroundColor = getOrganizationSetting.BackgroundColor,
                UseCustomSmtpServer = getOrganizationSetting.UseCustomSmtpServer,
                SmtpServerUserName = getOrganizationSetting.SmtpServerUserName,
                SmtpServerUrl = getOrganizationSetting.SmtpServerUrl,
                SmtpServerPort = getOrganizationSetting.SmtpServerPort,
                SmtpServerPassword = getOrganizationSetting.SmtpServerPassword,
                GoogleApiToken = getOrganizationSetting.GoogleApiToken
            };
        }

        public HashSet<OrganizationCultureListDto> ConvertToWebModel(HashSet<OrganizationCultureDbo> getOrganizationCultures)
        {
            return getOrganizationCultures
                .Select(x => new OrganizationCultureListDto()
                {
                    Id = x.Id,
                    IsDefault = x.IsDefault,
                    Name = x.Culture.Name
                })
                .ToHashSet();
        }

        public OrganizationSettingByUrlDto ConvertToWebModel2(OrganizationSettingDbo getOrganizationSetting)
        {
            return new OrganizationSettingByUrlDto()
            {
                FacebookLogin = getOrganizationSetting.FacebookLogin,
                GoogleLogin = getOrganizationSetting.GoogleLogin,
                PasswordReset = getOrganizationSetting.PasswordReset,
                Registration = getOrganizationSetting.Registration,
                Id = getOrganizationSetting.Id,
                Name = getOrganizationSetting.Organization.Name
            };
        }
    }
}
