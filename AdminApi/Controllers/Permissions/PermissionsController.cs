using AdminService.Permissions.Create.Command;
using AdminService.Permissions.Create.Dto;
using AdminService.Permissions.Delete.Command;
using AdminService.Permissions.Detail.Command;
using AdminService.Permissions.Detail.Dto;
using AdminService.Permissions.List.Command;
using AdminService.Permissions.List.Dto;
using AdminService.Permissions.Restore.Command;
using AdminService.Permissions.Update.Command;
using AdminService.Permissions.Update.Dto;
using Core.Base.Controller;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers.Permissions
{
    public class PermissionsController : BaseAdminController
    {
        private readonly IPermissionsCreateService _permissionsCreateService;
        private readonly IPermissionsDeleteService _permissionsDeleteService;
        private readonly IPermissionsDetailService _permissionsDetailService;
        private readonly IPermissionsListService _permissionsListService;
        private readonly IPermissionsUpdateService _permissionsUpdateService;
        private readonly IPermissionsRestoreService _permissionsRestoreService;

        public PermissionsController(
            IPermissionsCreateService permissionsCreateService,
            IPermissionsDeleteService permissionsDeleteService,
            IPermissionsDetailService permissionsDetailService,
            IPermissionsListService permissionsListService,
            IPermissionsUpdateService permissionsUpdateService,
            IPermissionsRestoreService permissionsRestoreService,
            ILogger<PermissionsController> logger
        )
            : base(logger)
        {
            _permissionsCreateService = permissionsCreateService;
            _permissionsListService = permissionsListService;
            _permissionsDetailService = permissionsDetailService;
            _permissionsUpdateService = permissionsUpdateService;
            _permissionsDeleteService = permissionsDeleteService;
            _permissionsRestoreService = permissionsRestoreService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<PermissionsDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(PermissionsCreateDto request)
        {
            try
            {
                ResultInsert result = await _permissionsCreateService.Execute(request, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PermissionsListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestWithoutParentDto request)
        {
            try
            {
                ResultTable<PermissionsListDto> result = await _permissionsListService.Execute(request.IsDeleted, [GetClientCulture()]);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(PermissionsDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                PermissionsDetailDto result = await _permissionsDetailService.Execute(request.Id, [GetClientCulture()]);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result<PermissionsDetailDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(PermissionsUpdateDto request)
        {
            try
            {
                Result result = await _permissionsUpdateService.Execute(request, GetLoggedUserId(), GetClientCulture(), null);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

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
                Result result = await _permissionsDeleteService.Execute(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                Result result = await _permissionsRestoreService.Execute(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
