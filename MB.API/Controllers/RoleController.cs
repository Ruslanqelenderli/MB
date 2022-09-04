using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.DTOs.RoleDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        private readonly ILogger<RoleController> logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            this.roleService = roleService;
            this.logger = logger;
        }


        [HttpGet("/Role/GetAllForStatusInclude")]
        public async Task<IActionResult> GetAllForStatusInclude()
        {
            logger.LogInformation("Start GetAllForStatusInclude method in RoleController.");
            var result = await roleService.GetAllForStatusAsync(true,"AppUsers");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in RoleController GetAllForStatusInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in RoleController GetAllForStatusInclude method");
                return NotFound(result.Message);
            }
        }

        [HttpPost("/Role/Add")]
        public async Task<IActionResult> Add(RoleAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in RoleController.");
            var result = await roleService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in RoleController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in RoleController Add method");
                return NotFound(result.Message);
            }
        }

        [HttpPut("/Role/Update")]
        public async Task<IActionResult> Update(RoleUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in RoleController.");
            var result = await roleService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in RoleController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in RoleController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/Role/Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation("Start Delete method in RoleController.");
            var result = await roleService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in RoleController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in RoleController Delete method");
                return NotFound(result.Message); ;
            }
        }

        [HttpGet("/Role/GetByIdInclude/")]
        public async Task<IActionResult> GetByIdInclude(Guid id)
        {
            logger.LogInformation("Start GetByIdInclude method in RoleController.");
            var result = await roleService.GetByIdAsync(id,"AppUsers");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in RoleController GetByIdInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in RoleController GetByIdInclude method");
                return NotFound(result.Message);
            }
        }
    }
}
