using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Course.Service;
using Services.Organization.Dto;
using Services.Organization.Filter;
using Services.Organization.Service;
using Services.Organization.Sort;
using Services.OrganizationSetting.Dto;
using Services.OrganizationSetting.Service;
using Services.Page.Dto;
using Services.Page.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

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
        public async Task<ActionResult> PriceList()
        {
            try
            {
                return await SendResponse(_pageService.PriceList());
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet("{organizationId}")]
        [ProducesResponseType(typeof(OrganizationDetailWebDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> GetOrganizationDetail(Guid organizationId)
        {
            try
            {
                return await SendResponse(await _organizationService.GetOrganizationDetailWeb(organizationId));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> GetOrganizationList([FromQuery] OrganizationFilter filter, [FromQuery] OrganizationSort sort, [FromQuery] SortDirection sortDirection, [FromQuery] BasePaging paging)
        {
            try
            {
                return await SendResponse(await _organizationService.GetList(null, false, GetClientCulture(), filter, sort.ToString(), sortDirection, paging));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganizationSettingByUrlDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> GetOrganizationSettingByUrl(string url)
        {
            try
            {
                return await SendResponse(await _organizationSettingService.GetOrganizationSettingByUrl(url));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
