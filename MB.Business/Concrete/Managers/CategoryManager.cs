using AutoMapper;
using MB.Business.Abstract.Services;
using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.ReturnResult;
using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Repositories;
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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productService;
        private readonly IMapper mapper;



        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper, IProductService productService)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.productService = productService;
        }


        public BusinessReturnResult<CategoryDto> Add(CategoryAddDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                data.CreateDate = DateTime.Now;
                var returnresult = categoryRepository.Add(data);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<CategoryDto> Delete(Guid Id)
        {
            try
            {
                var productresult =  productService.GetAllByCategoryId(Id, false);
                if (productresult.List != null)
                {
                    var deleteresult = productService.DeleteRange(productresult.List);
                }
                var returnresult = categoryRepository.Delete(Id);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }



        
        public BusinessReturnResult<CategoryDto> Update(CategoryUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = categoryRepository.Update(data);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
        public async Task<BusinessReturnResult<CategoryDto>> DeleteAsync(Guid Id)
        {
            try
            {
                var productresult = await productService.GetAllByCategoryIdAsync(Id,false);
                if (productresult.List!=null)
                {
                    var deleteresult = await productService.DeleteRangeAsync(productresult.List);
                }
                
                var returnresult = await categoryRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
        



        public async Task<BusinessReturnResult<CategoryDto>> AddAsync(CategoryAddDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                data.CreateDate = DateTime.Now;
                var returnresult = await categoryRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<CategoryDto>> UpdateAsync(CategoryUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<Category>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = await categoryRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<CategoryDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<CategoryDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<CategoryDto> GetAllForStatus(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = categoryRepository.GetAll(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<CategoryDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await categoryRepository.GetAllAsync(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<CategoryDto> GetById(Guid id, params string[] include)
        {
            try
            {
                var result = categoryRepository.Get(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<CategoryDto>> GetByIdAsync(Guid id, params string[] include)
        {
            try
            {
                var result = await categoryRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<CategoryDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<CategoryDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        
    }
}

