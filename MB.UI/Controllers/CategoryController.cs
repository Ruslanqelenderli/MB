using MB.UI.Helpers;
using MB.UI.Models.DTOs;
using MB.UI.Models.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MB.UI.Controllers
{
    
    public class CategoryController : Controller
    {
        public static string Token()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMzY2NTAzLCJleHAiOjE2NjIzODQ1MDMsImlhdCI6MTY2MjM2NjUwM30.DBXYcA_bZ0Ml43BLRWIkHR8PY0W9Eh4pLgJjGLxN520";
            return token;
        }
        public async Task<IActionResult> Index()
        {
           
            var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/categories", Token());

            TempData["Categories"] = categories;
            //+vm1hl0OyKZBtorJGZVZVc1awVcXBCFd+yJPRXwkYjQ=
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {


            

            var url = "http://localhost:5178/category/delete/" + id;
            var result = await Api<CategoryDto>.DeleteAsync(url, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Category/Index");
            }


            return NotFound();
        }
        public async Task<IActionResult> Add()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto model)
        {
            model.Status = true;
           
            if (!ModelState.IsValid)
            {

                return View(model);

            }

            var url = "http://localhost:5178/category/add";
            var result = await Api<CategoryDto>.PostAsync(url, model, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Category/Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(Guid id)
        {
            
            
            var product = await Api<CategoryDto>.GetAsync("http://localhost:5178/category/" + id, Token());
            var model = new CategoryUpdateDto();
            model.Id = product.FirstOrDefault().Id;
            model.Name = product.FirstOrDefault().Name;
            model.Status = product.FirstOrDefault().Status;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto model)
        {
            
            if (!ModelState.IsValid)
            {
                
                return View(model);

            }


            var url = "http://localhost:5178/category/update";
            var result = await Api<CategoryDto>.PutAsync(url, model, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Category/Index");
            }
            return View();
        }
    }
}
