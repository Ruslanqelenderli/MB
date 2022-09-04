using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }


        [HttpGet("/User/GetAllForStatusInclude")]
        public async Task<IActionResult> GetAllForStatusInclude()
        {
            logger.LogInformation("Start GetAllForStatusInclude method in UserController.");
            var result = await userService.GetAllForStatusAsync(true, "Products");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in UserController GetAllForStatusInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in UserController GetAllForStatusInclude method");
                return NotFound(result.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("/User/Add")]
        public async Task<IActionResult> Add(AppUserAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            logger.LogInformation("Start Add method in UserController.");
            var result = await userService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in UserController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in UserController Add method");
                return NotFound(result.Message);
            }
        }

        [HttpPut("/User/Update")]
        public async Task<IActionResult> Update(AppUserUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in UserController.");
            var result = await userService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in UserController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in UserController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/User/Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation("Start Delete method in UserController.");
            var result = await userService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in UserController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in UserController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/User/GetByIdInclude/")]
        public async Task<IActionResult> GetByIdInclude(Guid id)
        {
            logger.LogInformation("Start GetByIdInclude method in UserController.");
            var result = await userService.GetByIdAsync(id, "Products");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in UserController GetByIdInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in UserController GetByIdInclude method");
                return NotFound(result.Message);
            }
        }
    }
}
