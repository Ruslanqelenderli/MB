using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Concrete.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services
{
    public interface IProductService: IGenericService<ProductDto, BusinessReturnResult<ProductDto>>
    {
        Task<BusinessReturnResult<ProductDto>> UpdateAsync(ProductUpdateDto entity);
        BusinessReturnResult<ProductDto> Update(ProductUpdateDto entity);
        BusinessReturnResult<ProductDto> Add(ProductAddDto entity);
        Task<BusinessReturnResult<ProductDto>> AddAsync(ProductAddDto entity);
        BusinessReturnResult<ProductDto> GetAllForStatus(bool enableTracking = true,params string[] include);
        Task<BusinessReturnResult<ProductDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<ProductDto>> GetAllByCategoryIdAsync(Guid categoryid,bool enableTracking = true, params string[] include);
        BusinessReturnResult<ProductDto> GetAllByCategoryId(Guid categoryid,bool enableTracking = true, params string[] include);
        BusinessReturnResult<ProductDto> GetById(Guid id, params string[] include);
        Task<BusinessReturnResult<ProductDto>> GetByIdAsync(Guid id, params string[] include);
        Task<BusinessReturnResult<ProductDto>> DeleteRangeAsync(ICollection<ProductDto> products);
        BusinessReturnResult<ProductDto> DeleteRange(ICollection<ProductDto> products);
        Task<BusinessReturnResult<ProductDto>> GetAllByUserIdAsync(Guid userid, bool enableTracking = true, params string[] include);
        BusinessReturnResult<ProductDto> GetAllByUserId(Guid userid, bool enableTracking = true, params string[] include);


    }
}
