using CodebookService.LicenceList.Command;
using CodebookService.LicenceList.Dto;
using Core.Base.Controller;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.CodeBook;
using OrganizationService.Organization.OrganizationList.Command;
using OrganizationService.Organization.OrganizationList.Dto;
using OrganizationService.Organization.OrganizationList.Filter;
using OrganizationService.Organization.OrganizationList.Sort.Sort;
using OrganizationService.Organization.OrganizationWebDetail.Command;
using OrganizationService.Organization.OrganizationWebDetail.Dto;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Command;
using OrganizationService.OrganizationSetting.GetOrganizationSettingByUrl.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PublicApi.Controllers.Page
{
    [AllowAnonymous]
    public class PageController : BaseWebController
    {
        private readonly ILicenceListService _priceListService;
        private readonly IOrganizationList _organizationList;
        private readonly IOrganizationWebDetail _organizationWebDetail;
        private readonly IGetOrganizationSettingByUrlService _getOrganizationSettingByUrlService;

        public PageController(
            ILogger<PageController> logger,
            ILicenceListService priceListService,
            IOrganizationList organizationList,
            IOrganizationWebDetail organizationWebDetail,
            IGetOrganizationSettingByUrlService getOrganizationSettingByUrlService
        )
            : base(logger)
        {
            _priceListService = priceListService;
            _organizationList = organizationList;
            _organizationWebDetail = organizationWebDetail;
            _getOrganizationSettingByUrlService = getOrganizationSettingByUrlService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<LicenceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> PriceList()
        {
            try
            {
                return await SendResponse(
                    await _priceListService.Execute(null, false, new List<string>() { GetClientCulture() }, null, nameof(LicenseDbo.Priority), SortDirection.Ascending)
                );
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
                return await SendResponse(await _organizationWebDetail.Execute(organizationId, new List<string>() { GetClientCulture() }));
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
        public async Task<ActionResult> GetOrganizationList(
            [FromQuery] OrganizationFilter filter,
            [FromQuery] OrganizationSort sort,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                return await SendResponse(
                    await _organizationList.Execute(null, false, new List<string>() { GetClientCulture() }, filter, sort.ToString(), sortDirection, paging)
                );
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
                return await SendResponse(await _getOrganizationSettingByUrlService.Execute(x => x.ElearningUrl == url && x.Organization.IsDeleted == false, new List<string>() { GetClientCulture() }));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
