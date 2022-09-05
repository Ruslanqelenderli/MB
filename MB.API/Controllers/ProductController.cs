using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Concrete.ReturnResult;
using MB.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            this.productService = productService;
            this.logger = logger;
        }


        [HttpGet("/products")]
        public async Task<IActionResult> GetAllForStatusInclude()
         {
            logger.LogInformation("Start GetAllForStatusInclude method in ProductController.");
            var result = await productService.GetAllForStatusAsync(true,"AppUser","Category");
            
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController GetAllForStatusInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in ProductController GetAllForStatusInclude method");
                return NotFound(result.Message);
            }
        }

        [HttpPost("/product/add")]
        public async Task<IActionResult> Add(ProductAddDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Add method in ProductController.");
            var result = await productService.AddAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Add method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Add method");
                return NotFound(result.Message);
            }
        }

        [HttpPut("/product/update")]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Start Update method in ProductController.");
            var result=await productService.UpdateAsync(dto);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Update method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Update method");
                return NotFound(result.Message);
            }
        }

        [HttpDelete("/product/delete/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            logger.LogInformation("Start Delete method in ProductController.");
            var result= await productService.DeleteAsync(id);
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController Delete method");
                return Ok();
            }
            else
            {
                logger.LogError(result.Message + " in ProductController Delete method");
                return NotFound(result.Message);
            }
        }

        [HttpGet("/product/{id:Guid}")]
        public async Task<IActionResult> GetByIdInclude(Guid id)
        {
            logger.LogInformation("Start GetByIdInclude method in ProductController.");
            var result = await productService.GetByIdAsync(id,"Category","AppUser");
            if (result.Status)
            {
                logger.LogInformation(result.Message + " in ProductController GetByIdInclude method");
                return Ok(result.List);
            }
            else
            {
                logger.LogError(result.Message + " in ProductController GetByIdInclude method");
                return NotFound(result.Message);
            }
        }
    }
}
