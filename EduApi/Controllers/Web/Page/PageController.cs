﻿using Core.DataTypes;
using EduServices.Course.Service;
using EduServices.Organization.Dto;
using EduServices.Organization.Service;
using EduServices.OrganizationSetting.Dto;
using EduServices.OrganizationSetting.Service;
using EduServices.Page.Dto;
using EduServices.Page.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace EduApi.Controllers.Web.Page
{
    [AllowAnonymous]
    public class PageController : BaseWebController
    {
        private readonly IPageService _pageService;
        private readonly ICourseService _courseService;
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationSettingService _organizationSettingService;

        public PageController(
            IOrganizationSettingService organizationSettingService,
            IOrganizationService organizationService,
            ICourseService courseService,
            ILogger<PageController> logger,
            IPageService pageService
        )
            : base(logger)
        {
            _pageService = pageService;
            _courseService = courseService;
            _organizationService = organizationService;
            _organizationSettingService = organizationSettingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<PriceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult PriceList()
        {
            try
            {
                return SendResponse(_pageService.PriceList());
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet("{organizationId}")]
        [ProducesResponseType(typeof(OrganizationDetailWebDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetOrganizationDetail(Guid organizationId)
        {
            try
            {
                return SendResponse(_organizationService.GetOrganizationDetailWeb(organizationId));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetOrganizationList()
        {
            try
            {
                return SendResponse(_organizationService.GetList());
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationSettingByUrlDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetOrganizationSettingByUrl(string url)
        {
            try
            {
                return SendResponse(_organizationSettingService.GetOrganizationSettingByUrl(url));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
