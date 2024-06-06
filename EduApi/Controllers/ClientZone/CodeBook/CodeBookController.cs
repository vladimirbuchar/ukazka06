using Core.DataTypes;
using EduServices.CodeBookData.Dto;
using EduServices.CodeBookData.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CodeBook
{
    [ApiExplorerSettings(GroupName = "Codebook")]
    public class CodeBookController : BaseClientZoneController
    {
        private readonly ICodeBookService _codeBookService;

        public CodeBookController(
            ILogger<CodeBookController> logger,
            ICodeBookService codeBookService,
            IOrganizationRoleService organizationRoleService

        )
            : base(logger, organizationRoleService)
        {
            _codeBookService = codeBookService;
        }

        [HttpGet("{codeBookName}")]
        [ProducesResponseType(typeof(IEnumerable<CodeBookItemListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetCodeBookItems(string codeBookName)
        {
            try
            {
                return SendResponse(_codeBookService.GetCodeBookItems(codeBookName));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
