using AutoMapper;
using MB.Business.Concrete.DTOs;
using MB.Business.Concrete.DTOs.AppUserDtos;
using MB.Business.Concrete.DTOs.CategoryDtos;
using MB.Business.Concrete.DTOs.ProductDtos;
using MB.Business.Concrete.DTOs.RoleDtos;
using MB.Business.Concrete.ReturnResult;
using MB.DataAccess.Concrete.ReturnResult;
using MB.Entity.Entities;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.AutoMapper
{
    public class ProgramProfile:Profile
    {
        public ProgramProfile()
        {
            CreateMap<AppUser, AppUserDto>()
                .ForMember(model => model.AppRoleDto,act=>act.MapFrom(dto=>dto.AppRole))
                .ForMember(model => model.ProductDtos, act => act.MapFrom(dto => dto.Products));
            CreateMap<AppUserDto, AppUser>()
                .ForMember(model => model.AppRole, act => act.MapFrom(dto => dto.AppRoleDto))
                .ForMember(model => model.Products, act => act.MapFrom(dto => dto.ProductDtos));

            CreateMap<AppRole, AppRoleDto>()
                .ForMember(model => model.AppUserDtos, act => act.MapFrom(dto => dto.AppUsers));
            CreateMap<AppRoleDto, AppRole>()
                .ForMember(model => model.AppUsers, act => act.MapFrom(dto => dto.AppUserDtos));

            CreateMap<Product, ProductDto>()
                .ForMember(model => model.CategoryDto, act => act.MapFrom(dto => dto.Category))
                .ForMember(model => model.AppUserDto, act => act.MapFrom(dto => dto.AppUser));
            CreateMap<ProductDto, Product>()
                .ForMember(model => model.Category, act => act.MapFrom(dto => dto.CategoryDto))
                .ForMember(model => model.AppUser, act => act.MapFrom(dto => dto.AppUserDto));

            CreateMap<Category, CategoryDto>()
                .ForMember(model => model.ProductDtos, act => act.MapFrom(dto => dto.Products));
            CreateMap<CategoryDto, Category>()
                .ForMember(model => model.Products, act => act.MapFrom(dto => dto.ProductDtos));

            CreateMap<DataAccessReturnResult<Category>, BusinessReturnResult<CategoryDto>>();
            CreateMap< BusinessReturnResult<CategoryDto>, DataAccessReturnResult<Category>>();

            CreateMap<DataAccessReturnResult<Product>, BusinessReturnResult<ProductDto>>();
            CreateMap<BusinessReturnResult<ProductDto>, DataAccessReturnResult<Product>>();

            CreateMap<DataAccessReturnResult<AppUser>, BusinessReturnResult<AppUserDto>>();
            CreateMap<BusinessReturnResult<AppUserDto>, DataAccessReturnResult<AppUser>>();

            CreateMap<DataAccessReturnResult<AppRole>, BusinessReturnResult<AppRoleDto>>();
            CreateMap<BusinessReturnResult<AppRoleDto>, DataAccessReturnResult<AppRole>>();


            CreateMap<Expression<Func<Product, bool>>, Expression<Func<ProductDto, bool>>>();
            CreateMap<Expression<Func<ProductDto, bool>>, Expression<Func<Product, bool>>>();

            CreateMap<Expression<Func<Category, bool>>, Expression<Func<CategoryDto, bool>>>();
            CreateMap<Expression<Func<CategoryDto, bool>>, Expression<Func<Category, bool>>>();

            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();

            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryAddDto, Category>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserAddDto, AppUser>();

            CreateMap<AppUser, CategoryUpdateDto>();
            CreateMap<AppUserUpdateDto, AppUser>();

            CreateMap<AppRole, RoleAddDto>();
            CreateMap<RoleAddDto, AppRole>();

            CreateMap<AppRole,RoleUpdateDto>();
            CreateMap<RoleUpdateDto, AppRole>();

        }
    }
}
