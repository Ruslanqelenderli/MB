using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Concrete.ReturnResult;
using MB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services
{
    public interface ICategoryService: IGenericService<CategoryDto,BusinessReturnResult<CategoryDto>>
    {
        BusinessReturnResult<CategoryDto> GetAllForStatus(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<CategoryDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include);
        BusinessReturnResult<CategoryDto> GetById(Guid id, params string[] include);
        Task<BusinessReturnResult<CategoryDto>> GetByIdAsync(Guid id, params string[] include);
        Task<BusinessReturnResult<CategoryDto>> UpdateAsync(CategoryUpdateDto entity);
        BusinessReturnResult<CategoryDto> Update(CategoryUpdateDto entity);
        BusinessReturnResult<CategoryDto> Add(CategoryAddDto entity);
        Task<BusinessReturnResult<CategoryDto>> AddAsync(CategoryAddDto entity);
    }
}
