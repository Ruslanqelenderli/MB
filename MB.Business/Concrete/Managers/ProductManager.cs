using AutoMapper;
using MB.Business.Abstract.Services;
using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Concrete.ReturnResult;
using MB.DataAccess.Abstract;
using MB.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.Managers
{
    public class ProductManager :IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }


        public BusinessReturnResult<ProductDto> Add(ProductAddDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.Now;
                var returnresult = productRepository.Add(data);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<ProductDto> Delete(Guid Id)
        {
            try
            {
                var returnresult = productRepository.Delete(Id);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        

       
        public BusinessReturnResult<ProductDto> Update(ProductUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = productRepository.Update(data);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
        public async Task<BusinessReturnResult<ProductDto>> DeleteAsync(Guid Id)
        {
            try
            {
                var returnresult = await productRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
        

        

        public async Task<BusinessReturnResult<ProductDto>> AddAsync(ProductAddDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                data.Id = Guid.NewGuid();
                data.CreateDate = DateTime.Now;
                var returnresult = await productRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<ProductDto>> UpdateAsync(ProductUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Product>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = await productRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<ProductDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<ProductDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<ProductDto> GetAllForStatus(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = productRepository.GetAll(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult; 
                                                      
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
;                
            }
        }

        public async Task<BusinessReturnResult<ProductDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAllAsync(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<ProductDto> GetById(Guid id, params string[] include)
        {
            try
            {
                var result = productRepository.Get(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductDto>> GetByIdAsync(Guid id, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<ProductDto>> GetAllByCategoryIdAsync(Guid categoryid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAllAsync(x => x.CategoryId == categoryid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        

        public async Task<BusinessReturnResult<ProductDto>> DeleteRangeAsync(ICollection<ProductDto> products)
        {
            
            try
            {
                var entities = mapper.Map<ICollection<Product>>(products);
                var result = await productRepository.DeleteRangeAsync(entities);
                var returnresult=mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, true);
                return returnresult;
            }
        }

        public BusinessReturnResult<ProductDto> GetAllByCategoryId(Guid categoryid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result =productRepository.GetAll(x => x.CategoryId == categoryid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<ProductDto> DeleteRange(ICollection<ProductDto> products)
        {
            try
            {
                var entities = mapper.Map<ICollection<Product>>(products);
                var result = productRepository.DeleteRange(entities);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, true);
                return returnresult;
            }
        }

        

        public async Task<BusinessReturnResult<ProductDto>> GetAllByUserIdAsync(Guid userid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await productRepository.GetAllAsync(x => x.CategoryId == userid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<ProductDto> GetAllByUserId(Guid userid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = productRepository.GetAll(x => x.CategoryId == userid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<ProductDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<ProductDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }
    }
}
