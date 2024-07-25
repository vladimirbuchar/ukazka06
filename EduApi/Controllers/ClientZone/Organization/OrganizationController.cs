using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.Organization;
using Services.Organization.Dto;
using Services.Organization.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.Organization
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class OrganizationController : BaseClientZoneController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(
            ILogger<OrganizationController> logger,
            IOrganizationService organizationService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20AddOrganization&pageId=2
        /// </summary>>
        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create([FromBody] OrganizationCreateDto addOrganizationDto)
        {
            try
            {
                addOrganizationDto.UserId = GetLoggedUserId();
                return await SendResponse(await _organizationService.AddObject(addOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20GetOrganizationDetail&pageId=19
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(OrganizationDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto detail)
        {
            try
            {
                await CheckOrganizationPermition(detail.Id);
                return await SendResponse(await _organizationService.GetDetail(detail.Id, GetClientCulture()));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20UpdateOrganization&pageId=16
        /// </summary>

        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(OrganizationUpdateDto updateOrganizationDto)
        {
            try
            {
                await CheckOrganizationPermition(updateOrganizationDto.Id);
                return await SendResponse(await _organizationService.UpdateObject(updateOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20DeleteOrganization&pageId=18
        /// </summary>

        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                await CheckOrganizationPermition(request.Id);
                return await SendResponse(await _organizationService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> FileUpload([FromQuery] DetailRequestDto request, IFormFile file)
        {
            try
            {
                await CheckOrganizationPermition(request.Id);
                return await SendResponse(
                    await _organizationService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new OrganizationFileRepositoryDbo() { OrganizationId = request.Id, },
                        x => x.OrganizationId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
