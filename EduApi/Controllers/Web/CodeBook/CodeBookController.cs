using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CodeBookData.Dto;
using Services.CodeBookData.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.Web.CodeBook
{
    public class CodeBookController : BaseWebController
    {
        private readonly ICodebookService _codeBookService;

        public CodeBookController(ILogger<CodeBookController> logger, ICodebookService codeBookService)
            : base(logger)
        {
            _codeBookService = codeBookService;
        }

        [HttpGet("{codeBookName}")]
        [ProducesResponseType(typeof(IEnumerable<CodeBookListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> GetCodeBookItems(string codeBookName)
        {
            try
            {
                var response = await _codeBookService.GetCodeBookItems(codeBookName, IsLogged());
                return await SendResponse(response);
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
