using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly ILogger<CategoryController> logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            this.categoryService = categoryService;
            this.logger = logger;
        }


        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllForStatusInclude()
        {
            logger.LogInformation("Start GetAllForStatusInclude method in CategoryController.");
            var result = await categoryService.GetAllForStatusAsync(true,"Products");

            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController GetAllForStatusInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController GetAllForStatusInclude method");
                return NotFound(result.Message);
            }
        }

        [HttpPost("/category/add")]
        public async Task<IActionResult> Add(CategoryAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in ProductController.");
            var result = await categoryService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Add method");
                return NotFound(result.Message);
            }
        }

        [HttpPut("/category/update")]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in CategoryController.");
            var result = await categoryService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/category/delete/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation("Start Delete method in CategoryController.");
            var result = await categoryService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/category/{id:Guid}")]
        public async Task<IActionResult> GetByIdInclude(Guid id)
        {
            logger.LogInformation("Start GetByIdInclude method in CategoryController.");
            var result = await categoryService.GetByIdAsync(id,"Products");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in CategoryController GetByIdInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in CategoryController GetByIdInclude method");
                return NotFound(result.Message);
            }
        }
    }  
}
