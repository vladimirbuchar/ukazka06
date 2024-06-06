using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EduApi.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class BaseAdminController : BaseController
    {
        public BaseAdminController(ILogger<BaseAdminController> logger)
            : base(logger)
        {

        }
    }
}
