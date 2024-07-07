using Core.Constants;
using Core.DataTypes;
using Core.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace EduApi.Controllers
{
    [EnableCors("AllowInternal")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// write data to log
        /// </summary>
        /// <param name="apiIdentificator"></param>
        /// <param name="validate"></param>
        private void LogValidate(Result validate)
        {
            if (validate.IsError)
            {
                _logger.LogError("Validation error", validate.Errors);
            }
        }
        protected bool IsLogged()
        {
            return GetLoggedUserId() != Guid.Empty;
        }

        protected string GetClientCulture()
        {
            if (Request.Headers.Any(x => x.Key == Constants.CLIENT_CULTURE))
            {
                return Request.Headers.FirstOrDefault(x => x.Key == Constants.CLIENT_CULTURE).Value;
            }
            return Constants.DEFAULT_CULTURE;
        }

        protected Guid GetLoggedUserId()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (authHeader == null)
            {
                return Guid.Empty;
            }
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            Guid id = Guid.Empty;
            Guid.TryParse(tokenS.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value, out id);
            return id;
        }

        private void LogValidate<T>(Result<T> validate)
        {
            if (validate.IsError)
            {
                _logger.LogError("Validation error", validate.Errors);
            }
        }

        /// <summary>
        /// send system error
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected ActionResult SendSystemError(Exception ex)
        {
            Result validation = new Result();
            if (ex is PermitionDeniedException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, SystemErrorItem.PERMITION_DENIED));
            }
            else if (ex is LicenseException)
            {
                validation.AddResultStatus(new ValidationMessage(MessageType.ERROR, SystemErrorItem.BAD_LICENSE));
            }
            if (validation.IsError)
            {
                return SendResponse(validation);
            }
            _logger.LogCritical(SystemErrorItem.SYSTEM_EXCEPTION, ex);
            return StatusCode(500, new SystemError(SystemErrorItem.SYSTEM_EXCEPTION));
        }

        /// <summary>
        /// send response with result
        /// </summary>
        /// <param name="validation"></param>
        /// <r;eturns></returns>
        protected ActionResult SendResponse(Result response)
        {
            LogValidate(response);
            if (
                response.IsError
                && response.Contains(new ValidationMessage(MessageType.ERROR, SystemErrorItem.PERMITION_DENIED))
            )
            {
                return StatusCode(403);
            }
            else if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        /// <summary>
        /// send response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ActionResult SendResponse<T>(T response)
        {
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        protected ActionResult SendResponse<T>(Result<T> response)
        {
            LogValidate(response);
            if (response == null)
            {
                return NotFound();
            }
            if (response.IsError && response.Contains(new ValidationMessage(MessageType.ERROR, SystemErrorItem.PERMITION_DENIED)))
            {
                return StatusCode(403);
            }
            else if (response.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
