using MB.Business.Abstract.Services.GenericService;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.DTOs.RoleDtos;
using MB.Business.Concrete.ReturnResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services
{
    public interface IRoleService:IGenericService<AppRoleDto,BusinessReturnResult<AppRoleDto>>
    {
        BusinessReturnResult<AppRoleDto> GetAllForStatus(bool enableTracking = true, params string[] include);
        Task<BusinessReturnResult<AppRoleDto>> GetAllForStatusAsync(bool enableTracking = true, params string[] include);
        BusinessReturnResult<AppRoleDto> GetById(Guid id, params string[] include);
        Task<BusinessReturnResult<AppRoleDto>> GetByIdAsync(Guid id, params string[] include);
        Task<BusinessReturnResult<AppRoleDto>> UpdateAsync(RoleUpdateDto entity);
        BusinessReturnResult<AppRoleDto> Update(RoleUpdateDto entity);
        BusinessReturnResult<AppRoleDto> Add(RoleAddDto entity);
        Task<BusinessReturnResult<AppRoleDto>> AddAsync(RoleAddDto entity);
    }
}
