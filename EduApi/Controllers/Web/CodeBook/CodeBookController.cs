using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CodeBookData.Dto;
using Services.CodeBookData.Service;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.Web.CodeBook
{
    public class CodeBookController : BaseWebController
    {
        private readonly ICodeBookService _codeBookService;

        public CodeBookController(
            ILogger<CodeBookController> logger,
            ICodeBookService codeBookService
        )
            : base(logger)
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
                return SendResponse(_codeBookService.GetCodeBookItems(codeBookName, IsLogged()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
