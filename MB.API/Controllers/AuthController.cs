using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs;
using MB.Business.Helpers.Tokens;
using MB.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configurationService;

        public AuthController(IUserService userService, IConfiguration configurationService)
        {
            this.userService = userService;
            this.configurationService = configurationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userService.GetForLoginAsync(dto);
            var returnresult = new LoginResultDto();
            if (user.List == null)
            {
                returnresult.Id = Guid.Empty;
                returnresult.Result = false;
                returnresult.Message = "Username or password is not correct.";
                returnresult.Token = "Username or password is not correct.";
                return Ok(returnresult);
            }
            else
            {
                var token = TokenGenerator.GenerateJwtToken(user.List.FirstOrDefault());
                return Ok(new LoginResultDto
                {
                    Id = user.List.FirstOrDefault().Id,
                    Token = token,
                    Result = true,
                    Message = "Succeed"
                }) ;
            }
            
        }

        
    }
}
