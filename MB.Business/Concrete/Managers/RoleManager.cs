using AutoMapper;
using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.RoleDtos;
using MB.Business.Concrete.ReturnResult;
using MB.DataAccess.Abstract;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.Managers
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUserService userService;
        private readonly IProductService productService;
        private readonly IMapper mapper;



        public RoleManager(IRoleRepository roleRepository, IMapper mapper, IUserService userService, IProductService productService)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.userService = userService;
            this.productService = productService;
        }
        public BusinessReturnResult<AppRoleDto> Add(RoleAddDto entity)
        {
            try
            {
                var data = mapper.Map<AppRole>(entity);
                data.CreateDate = DateTime.Now;
                var returnresult = roleRepository.Add(data);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppRoleDto>> AddAsync(RoleAddDto entity)
        {
            try
            {
                var data = mapper.Map<AppRole>(entity);
                data.CreateDate = DateTime.Now;
                var returnresult = await roleRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<AppRoleDto> Delete(Guid Id)
        {
            try
            {
                var returnresult = roleRepository.Delete(Id);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppRoleDto>> DeleteAsync(Guid Id)
        {
            try
            {
                var users = await userService.GetAllByRoleIdAsync(Id, false, "Products");
                if (users.List != null)
                {
                    var products = new List<ProductDto>();
                    foreach (var user in users.List)
                    {
                        products.AddRange(user.ProductDtos);
                    }
                    await productService.DeleteRangeAsync(products);

                    await userService.DeleteRangeAsync(users.List);
                    
                }
                var returnresult = await roleRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<AppRoleDto> GetAllForStatus(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = roleRepository.GetAll(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppRoleDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppRoleDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppRoleDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await roleRepository.GetAllAsync(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppRoleDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppRoleDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<AppRoleDto> GetById(Guid id, params string[] include)
        {
            try
            {
                var result = roleRepository.Get(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppRoleDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppRoleDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppRoleDto>> GetByIdAsync(Guid id, params string[] include)
        {
            try
            {
                var result = await roleRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppRoleDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppRoleDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }



        public BusinessReturnResult<AppRoleDto> Update(RoleUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<AppRole>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = roleRepository.Update(data);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppRoleDto>> UpdateAsync(RoleUpdateDto entity)
        {
            try
            {
                var data = mapper.Map<AppRole>(entity);
                data.UpdateDate = DateTime.Now;
                var returnresult = await roleRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<AppRoleDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppRoleDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

    }
}
