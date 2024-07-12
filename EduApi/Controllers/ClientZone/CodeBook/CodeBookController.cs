using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CodeBookData.Dto;
using Services.CodeBookData.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CodeBook
{
    [ApiExplorerSettings(GroupName = "Codebook")]
    public class CodeBookController : BaseClientZoneController
    {
        private readonly ICodebookService _codeBookService;

        public CodeBookController(
            ILogger<CodeBookController> logger,
            ICodebookService codeBookService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _codeBookService = codeBookService;
        }

        [HttpGet("{codeBookName}")]
        [ProducesResponseType(typeof(IEnumerable<CodeBookListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GetCodeBookItems(string codeBookName)
        {
            try
            {
                return SendResponse(_codeBookService.GetCodeBookItems(codeBookName, IsLogged()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
