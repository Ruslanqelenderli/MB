using MB.UI.Helpers;
using MB.UI.Models.DTOs;
using MB.UI.Models.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace MB.UI.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMjgwMjI4LCJleHAiOjE2NjIyOTgyMjgsImlhdCI6MTY2MjI4MDIyOH0.Kp2dqg1k_46I_y_qZWoeM_X5lXVtmzsdnOEtQgFvHGY";
            var categories = await Api<CategoryDto>.GetAsync("http://localhost:5178/Category/GetAllForStatusInclude", token);

            TempData["Categories"] = categories;
            //+vm1hl0OyKZBtorJGZVZVc1awVcXBCFd+yJPRXwkYjQ=
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {


            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMjgwMjI4LCJleHAiOjE2NjIyOTgyMjgsImlhdCI6MTY2MjI4MDIyOH0.Kp2dqg1k_46I_y_qZWoeM_X5lXVtmzsdnOEtQgFvHGY";

            var url = "http://localhost:5178/Category/Delete/" + id;
            var result = await Api<CategoryDto>.DeleteAsync(url, token);
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
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMjgwMjI4LCJleHAiOjE2NjIyOTgyMjgsImlhdCI6MTY2MjI4MDIyOH0.Kp2dqg1k_46I_y_qZWoeM_X5lXVtmzsdnOEtQgFvHGY";
            if (!ModelState.IsValid)
            {

                return View(model);

            }

            var url = "http://localhost:5178/Category/Add";
            var result = await Api<CategoryDto>.PostAsync(url, model, token);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Category/Index");
            }
            return NotFound();
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMjgwMjI4LCJleHAiOjE2NjIyOTgyMjgsImlhdCI6MTY2MjI4MDIyOH0.Kp2dqg1k_46I_y_qZWoeM_X5lXVtmzsdnOEtQgFvHGY";
            
            var product = await Api<CategoryDto>.GetAsync("http://localhost:5178/Category/GetByIdInclude/" + id, token);
            var model = new CategoryUpdateDto();
            model.Id = product.FirstOrDefault().Id;
            model.Name = product.FirstOrDefault().Name;
            model.Status = product.FirstOrDefault().Status;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto model)
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI4N2NiNDhmNC00MDg5LTRjYTgtODE3YS0wMjRkZDQzMmMzMTkiLCJuYW1lIjoicnVzbGFuLmdhbGFuZGFybGlAZ21haWwuY29tIiwibmJmIjoxNjYyMjgwMjI4LCJleHAiOjE2NjIyOTgyMjgsImlhdCI6MTY2MjI4MDIyOH0.Kp2dqg1k_46I_y_qZWoeM_X5lXVtmzsdnOEtQgFvHGY";
            if (!ModelState.IsValid)
            {
                
                return View(model);

            }


            var url = "http://localhost:5178/Category/Update";
            var result = await Api<CategoryDto>.PutAsync(url, model, token);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Category/Index");
            }
            return View();
        }
    }
}
