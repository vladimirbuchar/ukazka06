using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Model.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Controller
{
    [Route("api/clientzone/[controller]/[action]")]
    [Authorize(Policy = "ClientPolicy")]
    [ApiExplorerSettings(GroupName = "Course")]
    public class BaseClientZoneController : BaseController
    {
        private readonly EduDbContext _eduDbContext;

        public BaseClientZoneController(ILogger<BaseClientZoneController> logger, EduDbContext eduDbContext)
            : base(logger)
        {
            _eduDbContext = eduDbContext;
        }

        protected override bool IsLogged()
        {
            return GetLoggedUserId() != Guid.Empty;
        }

        private Dictionary<Guid, List<string>> GetUserRoleInOrganization()
        {
            JwtSecurityTokenHandler handler = new();
            string authHeader = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (authHeader == null)
            {
                return [];
            }
            authHeader = authHeader.Replace("Bearer ", "");
            Microsoft.IdentityModel.Tokens.SecurityToken jsonToken = handler.ReadToken(authHeader);
            JwtSecurityToken tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            return JsonConvert.DeserializeObject<Dictionary<Guid, List<string>>>(
                tokenS.Claims.FirstOrDefault(x => x.Type == Constants.Constants.USER_ORGANIZATION_ROLE).Value
            );
        }

        /// <summary>
        /// check user permition in organization
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        protected async Task CheckOrganizationPermition(Guid organizationId)
        {
            string route = Request.Path.Value.Trim('/');
            route = route.Normalize(NormalizationForm.FormKD);  // Normalizace řetězce
            /*byte[] bytes = Encoding.Default.GetBytes(route);
            route = Encoding.Default.GetString(bytes);*/

            if (
                _eduDbContext != null
                &&
               (await _eduDbContext
                .Set<PermissionsDbo>()
                .Include(x => x.Route)
                .Include(x => x.OrganizationRole)
                .ThenInclude(x => x.UserInOrganizations.Where(x => x.IsDeleted == false))
                .FirstOrDefaultAsync(x =>
                x.IsDeleted == false &&
                     EF.Functions.Collate(x.Route.Route, "Latin1_General_BIN2") == route
                    && x.OrganizationRole.UserInOrganizations.Any(y => y.OrganizationId == organizationId)
                    && x.OrganizationRole.UserInOrganizations.Any(y => y.UserId == GetLoggedUserId())
                    && GetUserRoleInOrganization().GetValueOrDefault(organizationId).Contains(x.OrganizationRole.SystemIdentificator))) == null
            )
            {
                throw new PermitionDeniedException();
            }
        }

        protected string GetToken()
        {
            string token = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            token = token.Replace("Bearer ", "");
            return token;
        }

        protected string GetApiVersion()
        {
            return Constants.Constants.DEFAULT_VERSION;
        }
    }
}
