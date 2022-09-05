using MB.UI.Helpers;
using MB.UI.Models.DTOs;
using MB.UI.Models.DTOs.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace MB.UI.Controllers
{
   
    public class HomeController : Controller
    {
        public static string Token()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMzY2NTAzLCJleHAiOjE2NjIzODQ1MDMsImlhdCI6MTY2MjM2NjUwM30.DBXYcA_bZ0Ml43BLRWIkHR8PY0W9Eh4pLgJjGLxN520";
            return token;
        }
        public async  Task<IActionResult> Index()
        {
            
            
           
            var products = await Api<ProductDto>.GetAsync("http://localhost:5178/products", Token());
            
            TempData["Products"] = products;
            //+vm1hl0OyKZBtorJGZVZVc1awVcXBCFd+yJPRXwkYjQ=
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
           

            
            
            var url = "http://localhost:5178/product/delete/"+id;
            var result = await Api<ProductDto>.DeleteAsync(url, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Home/Index");
            }
            
            
            return NotFound();
        }
        public async Task<IActionResult> Add()
        {
           
            var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/categories", Token());
            TempData["Categories"] = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto model)
        {
            model.Status = true;
            model.AppUserId = new Guid("87cb48f4-4089-4ca8-817a-024dd432c319");
            
            if (!ModelState.IsValid)
            {

                var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/categories", Token());
                TempData["Categories"] = categories;
                return View(model);

            } 
           
            var url = "http://localhost:5178/product/add";
            var result = await Api<ProductDto>.PostAsync(url, model, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Home/Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Update(Guid id)
        {
           
            var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/categories", Token());
            TempData["Categories"] = categories;
            var product= await Api<ProductDto>.GetAsync("http://localhost:5178/product/"+id, Token());
            var model = new ProductUpdateDto();
            model.Id = product.FirstOrDefault().Id;
            model.Name = product.FirstOrDefault().Name;
            model.Count = product.FirstOrDefault().Count;
            model.Status = product.FirstOrDefault().Status;
            model.CategoryId = product.FirstOrDefault().CategoryId;
            model.AppUserId = product.FirstOrDefault().AppUserId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto model)
        {
            
            if (!ModelState.IsValid)
            {
                var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/categories", Token());
                TempData["Categories"] = categories;
                return View(model);

            }
            

            var url = "http://localhost:5178/product/update";
            var result = await Api<ProductDto>.PutAsync(url,model, Token());
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

    }
}
