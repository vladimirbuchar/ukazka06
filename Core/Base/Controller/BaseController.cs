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
using System.Threading.Tasks;

namespace Core.Base.Controller
{
    [EnableCors("AllowInternal")]
    [ApiController]
    public class BaseController(ILogger<BaseController> logger) : ControllerBase
    {
        private readonly ILogger<BaseController> _logger = logger;

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

        protected virtual bool IsLogged()
        {
            return false;
        }

        protected string GetClientCulture()
        {
            return Request.Headers.Any(x => x.Key == Core.Constants.Constants.CLIENT_CULTURE)
                ? Request.Headers.FirstOrDefault(x => x.Key == Core.Constants.Constants.CLIENT_CULTURE).Value
                : Core.Constants.Constants.DEFAULT_CULTURE;
        }

        protected Guid GetLoggedUserId()
        {
            JwtSecurityTokenHandler handler = new();
            string authHeader = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (authHeader == null)
            {
                return Guid.Empty;
            }
            authHeader = authHeader.Replace("Bearer ", "");
            Microsoft.IdentityModel.Tokens.SecurityToken jsonToken = handler.ReadToken(authHeader);
            JwtSecurityToken tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            Guid id = Guid.Empty;
            _ = Guid.TryParse(tokenS.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value, out id);
            return id;
        }



        /// <summary>
        /// send system error
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected async Task<ActionResult> SendSystemError(Exception ex)
        {
            Result validation = new();
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
                return await SendResponse(validation);
            }
            _logger.LogCritical(SystemErrorItem.SYSTEM_EXCEPTION, ex);
            return StatusCode(500, new SystemError(SystemErrorItem.SYSTEM_EXCEPTION));
        }

        /// <summary>
        /// send response with result
        /// </summary>
        /// <param name="validation"></param>
        protected async Task<ActionResult> SendResponse(Result response)
        {
            if (response == null)
            {
                return NotFound();
            }
            LogValidate(response);
            if (response.IsError && response.Contains(new ValidationMessage(MessageType.ERROR, SystemErrorItem.PERMITION_DENIED)))
            {
                return await Task.FromResult(StatusCode(403));
            }
            else if (response.IsError)
            {
                return BadRequest(response);
            }
            return await Task.FromResult(Ok(response));
        }

        /// <summary>
        /// send response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected async Task<ActionResult> SendResponse<T>(T response)
        {
            return response == null ? await Task.FromResult(NotFound()) : await Task.FromResult(Ok(response));
        }
    }
}
