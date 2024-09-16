using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Base.Controller
{
    [Route("api/web/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "Public")]
    public class BaseWebController : BaseController
    {
        public BaseWebController(ILogger<BaseWebController> logger)
            : base(logger) { }
    }
}
