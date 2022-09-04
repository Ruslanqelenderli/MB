using MB.UI.Helpers;
using MB.UI.Helpers.GenerateToken;
using MB.UI.Models.DTOs;
using MB.UI.Models.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MB.UI.Controllers
{
    public class AccountController : Controller
    {
        public static string Token()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMzMzMjE2LCJleHAiOjE2NjIzNTEyMTYsImlhdCI6MTY2MjMzMzIxNn0.-BWc6dNEWJbrWhRvLmg4l281CDE4zJr-M4SSyiz24tw";
            return token;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if(!ModelState.IsValid) return View(model);
            var url = "http://localhost:5178/api/Auth";
            HttpResponseMessage response = await Api<LoginResultDto>.PostAsync(url, model);
            var jsonstring = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<LoginResultDto>(jsonstring);
            if (values.Result)
            {
                //JwtTokenGenerator.GenerateJwtToken(values);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.FalseData = values.Message;
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var url = "http://localhost:5178/User/Add";
            var result = await Api<AppUserDto>.PostAsync(url, model);
            if (result.IsSuccessStatusCode)
            {
                TempData["Registered"] = "Registered";
                return RedirectToAction("Login", "Manage");
            }
            ViewBag.Error = "Error";
            return View();
        }

    }
}
