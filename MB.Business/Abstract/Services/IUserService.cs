using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.ReturnResult;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services
{
    public interface IUserService:IGenericService<AppUserDto,BusinessReturnResult<AppUserDto>>
    {
        Task<BusinessReturnResult<AppUserDto>> GetForLoginAsync(LoginDto dto);
        BusinessReturnResult<AppUserDto> GetAllForStatus(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<AppUserDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include);
        BusinessReturnResult<AppUserDto> GetById(Guid id, params string[] include);
        Task<BusinessReturnResult<AppUserDto>> GetByIdAsync(Guid id, params string[] include);
        Task<BusinessReturnResult<AppUserDto>> UpdateAsync(AppUserUpdateDto entity);
        BusinessReturnResult<AppUserDto> Update(AppUserUpdateDto entity);
        BusinessReturnResult<AppUserDto> Add(AppUserAddDto entity);
        Task<BusinessReturnResult<AppUserDto>> AddAsync(AppUserAddDto entity);
        Task<BusinessReturnResult<AppUserDto>> GetAllByRoleIdAsync(Guid roleid, bool enableTracking = true, params string[] include);
        BusinessReturnResult<AppUserDto> GetAllByRoleId(Guid roleid, bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<AppUserDto>> DeleteRangeAsync(ICollection<AppUserDto> users);
        BusinessReturnResult<AppUserDto> DeleteRange(ICollection<AppUserDto> users);
    }
}
