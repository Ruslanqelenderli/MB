using AutoMapper;
using MB.Business.Abstract.Services;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.ReturnResult;
using MB.Business.Helpers.PasswordHasher;
using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Repositories;
using MB.Entity.Entities;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IProductService productService;
        private readonly IMapper mapper;



        public UserManager(IUserRepository userRepository, IMapper mapper, IProductService productService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.productService = productService;
        }
        public BusinessReturnResult<AppUserDto> Add(AppUserAddDto entity)
        {
            try
            {
                if(entity.AppRoleId==Guid.Empty) entity.AppRoleId = new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915");
                if (entity.Status == false) entity.Status = true;
                var data = mapper.Map<AppUser>(entity);
                data.PasswordHash=Hasher.HashPassword(data.PasswordHash);
                data.CreateDate = DateTime.Now;
                var returnresult = userRepository.Add(data);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> AddAsync(AppUserAddDto entity)
        {
            try
            {
                if (entity.AppRoleId == Guid.Empty) entity.AppRoleId = new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915");
                if (entity.Status == false) entity.Status = true;
                var data = mapper.Map<AppUser>(entity);
                data.PasswordHash = Hasher.HashPassword(entity.Password);
                data.CreateDate = DateTime.Now;
                var returnresult = await userRepository.AddAsync(data);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<AppUserDto> Delete(Guid Id)
        {
            try
            {
                var productresult = productService.GetAllByUserId(Id, false);
                if (productresult.List != null)
                {
                    var deleteresult = productService.DeleteRange(productresult.List);
                }
                var returnresult = userRepository.Delete(Id);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> DeleteAsync(Guid Id)
        {
            try
            {
                var productresult = await productService.GetAllByUserIdAsync(Id, false);
                if (productresult.List != null)
                {
                    var deleteresult = await productService.DeleteRangeAsync(productresult.List);
                }
                var returnresult = await userRepository.DeleteAsync(Id);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public BusinessReturnResult<AppUserDto> DeleteRange(ICollection<AppUserDto> users)
        {
            try
            {
                var entities = mapper.Map<ICollection<AppUser>>(users);
                var result = userRepository.DeleteRange(entities);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, true);
                return returnresult;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> DeleteRangeAsync(ICollection<AppUserDto> users)
        {
            try
            {
                var entities = mapper.Map<ICollection<AppUser>>(users);
                var result = await userRepository.DeleteRangeAsync(entities);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, true);
                return returnresult;
            }
        }

        public BusinessReturnResult<AppUserDto> GetAllByRoleId(Guid roleid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = userRepository.GetAll(x => x.AppRoleId == roleid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> GetAllByRoleIdAsync(Guid roleid, bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await userRepository.GetAllAsync(x => x.AppRoleId == roleid,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<AppUserDto> GetAllForStatus(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = userRepository.GetAll(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include)
        {
            try
            {
                var result = await userRepository.GetAllAsync(x => x.Status == true,
                                                      enableTracking,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public BusinessReturnResult<AppUserDto> GetById(Guid id, params string[] include)
        {
            try
            {
                var result = userRepository.Get(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> GetByIdAsync(Guid id, params string[] include)
        {
            try
            {
                var result = await userRepository.GetAsync(x => x.Id == id,
                                                      include);
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(result);
                return returnresult;

            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
                ;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> GetForLoginAsync(LoginDto dto)
        {
            try
            {
                var data = await userRepository.GetAsync(x=>x.Email==dto.Email && x.PasswordHash==Hasher.HashPassword(dto.Password));
                var returnresult = mapper.Map<BusinessReturnResult<AppUserDto>>(data);
                return returnresult;
            }
            catch (Exception ex)
            {
                var returnresult = new BusinessReturnResult<AppUserDto>();
                returnresult.MainMethod(ex.Message, false);
                return returnresult;
            }
        }

        public BusinessReturnResult<AppUserDto> Update(AppUserUpdateDto entity)
        {
            try
            {
                if (entity.AppRoleId == Guid.Empty) entity.AppRoleId = new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915");
                if (entity.Status == false) entity.Status = true;
                var data = mapper.Map<AppUser>(entity);
                data.PasswordHash = Hasher.HashPassword(data.PasswordHash);
                data.UpdateDate = DateTime.Now;
                var returnresult = userRepository.Update(data);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<BusinessReturnResult<AppUserDto>> UpdateAsync(AppUserUpdateDto entity)
        {
            try
            {
                if (entity.AppRoleId == Guid.Empty) entity.AppRoleId = new Guid("e8f0130a-b4ac-46af-8ab8-825082ead915");
                if (entity.Status == false) entity.Status = true;
                var data = mapper.Map<AppUser>(entity);
                data.PasswordHash = Hasher.HashPassword(entity.Password);
                data.UpdateDate = DateTime.Now;
                var returnresult = await userRepository.UpdateAsync(data);
                var result = mapper.Map<BusinessReturnResult<AppUserDto>>(returnresult);
                return result;
            }
            catch (Exception ex)
            {
                var result = new BusinessReturnResult<AppUserDto>();
                result.MainMethod(ex.Message, false);
                return result;
            }
        }
    }
}
